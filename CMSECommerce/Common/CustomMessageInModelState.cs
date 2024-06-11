using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CMSECommerce.Common;

public static class CustomMessageInValidModelState
{
    public static void DecimalMessageError(string key, ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
        {
            // Ricavo l'eventuale invalidazione del campo Price
            var priceError = modelState.Where(x => x.Value.ValidationState == ModelValidationState.Invalid && x.Key == key).FirstOrDefault();
            if (priceError.Value.RawValue is string && (string)priceError.Value.RawValue == "")
            {
                modelState[key].Errors[0] = new ModelError("Il campo non è stato valorizzato.");
                return;
            }
            if (priceError.Value.RawValue is string && !decimal.TryParse((string)priceError.Value.RawValue, out _))
            {
                modelState[key].Errors[0] = new ModelError("Il valore indicato non è una valuta.");
                return;
            }
        }

    }
}
