using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SureAppTest.Common.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MediCareWebService;

namespace SureAppTest.ViewModels
{
	public class MediSupplierPageViewModel : ViewModelBase
	{
        private readonly IMediCareService mediCareService;

        public MediSupplierPageViewModel(INavigationService navigationService, IMediCareService mediCareService) : base(navigationService)
        {
            Title = "Medi Supplier";

            this.mediCareService = mediCareService;
        }

        private ObservableCollection<SupplierData> supplierDataList;
        public ObservableCollection<SupplierData> SupplierDataList
        {
            get { return supplierDataList; }
            set { SetProperty(ref supplierDataList, value); }
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            IsBusy = true;

            var res = await mediCareService.GetSupplierByCity("California");
            this.SupplierDataList = new ObservableCollection<SupplierData>(res ?? Enumerable.Empty<SupplierData>());

            IsBusy = false;
        }

    }
}
