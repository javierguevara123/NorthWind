﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Result.Entities
{
    public class Result<ErrorResultType>
    {
        public ErrorResultType ErrorValue { get; private set; }
        public bool HasError { get; private set; }
        public Result()
        {
            HasError = false;
        }

        public Result(ErrorResultType errorValue)
        {
            HasError = true;
            ErrorValue = errorValue;

        }

        public void HandleResult(
 Action<ErrorResultType> whenHasErrorAction,
 Action whenIsSuccessAction = null)
        {
            if (HasError)
                whenHasErrorAction(ErrorValue);
            else
                whenIsSuccessAction?.Invoke();
        }

    }
}
