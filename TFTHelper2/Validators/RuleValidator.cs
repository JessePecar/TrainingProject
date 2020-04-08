using System;
using System.Collections.Generic;
using TFTHelper2.ViewModels.Base;

namespace TFTHelper2.Validators
{
    public class RuleValidator : IRuleValidator
    {
        #region private
        private static Dictionary<string, object> RuleCache = new Dictionary<string, object> { };

        public void ApplyPreLoadRules(string ruleContext, BaseViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void ApplyValidationRules(string ruleContext, BaseViewModel viewModel)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
