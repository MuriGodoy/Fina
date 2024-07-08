using Fina.Core.Handlers;
using Fina.Core.Requests.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fina.App.Pages.Transactions;

public class CreateTransactionPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public CreateTransactionRequest InputModel { get; set; } = null!;
    #endregion

    #region Services
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ITransactionHandler Handler { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.CreateAsync(InputModel);

            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/transacoes");
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }
    #endregion
}
