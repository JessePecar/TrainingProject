using System;
using TFTHelper2.ViewModels.Base;

namespace TFTHelper2.Validators
{
    public interface IRuleValidator
    {
        void ApplyPreLoadRules(string ruleContext, BaseViewModel viewModel);
        void ApplyValidationRules(string ruleContext, BaseViewModel viewModel);
    }
}
