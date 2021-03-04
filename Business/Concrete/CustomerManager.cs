﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;

namespace Business.Concrete
{
    [SecuredOperation("Customer.Admin")]
    public class CustomerManager: ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        [SecuredOperation("Customer.Add")]
        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length <= 2)
            {
                return new ErrorResult(Messages.CompanyNameInvalid);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);

        }

        [SecuredOperation("Customer.Delete")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Customer> GetById(int id)
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<Customer>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(b => b.UserId == id));
        }

        [SecuredOperation("Customer.Update")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

    }
}
