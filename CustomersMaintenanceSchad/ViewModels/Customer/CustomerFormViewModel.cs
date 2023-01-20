using CommunityToolkit.Mvvm.Input;
using CustomersMaintenanceSchad.Models;
using CustomersMaintenanceSchad.Services.helpers;
using CustomersMaintenanceSchad.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomersMaintenanceSchad.ViewModels
{
    public class CustomerFormViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerTypeService _customerTypeService;
        private readonly IMessageService _messageService;

        private Customer _existingCustomer;
        private Customer _customer;
        public Customer Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CustomerType> CustomerTypes { get; set; }

        private CustomerType selectedCustomerType;
        public CustomerType SelectedCustomerType
        {
            get => selectedCustomerType;
            set
            {
                selectedCustomerType = value;
                OnPropertyChanged();
            }
        }


        //To keep windows close simple
        public Action Close;
        public bool HasChanged;

        public ICommand ExecuteCustomerCommand { get; set; }

        public CustomerFormViewModel(ICustomerService customerService, ICustomerTypeService customerTypeService, IMessageService messageService)
        {
            _customerService = customerService;
            _customerTypeService = customerTypeService;
            _messageService = messageService;

            Customer = new Customer();
            CustomerTypes = new ObservableCollection<CustomerType>();

            ExecuteCustomerCommand = new AsyncRelayCommand(ExecuteCustomerAction);
        }

        private async Task ExecuteCustomerAction()
        {
            try
            {
                if (Validations() == false)
                {
                    return;
                }

                if (_messageService.ShowConfirmationMessage($"Desea {(CustomerExist() ? "Editar" : "Crear")} este cliente?") == false)
                {
                    return;
                }

                //setting customer type
                Customer.CustomerTypeId = selectedCustomerType.Id;
                Customer.CustomerType = selectedCustomerType;

                if (CustomerExist())
                {
                    SetExistingCustomerValues();
                    _ = await _customerService.Update(_existingCustomer);
                    _messageService.ShowMessage("Se ha editado el cliente correctamente");
                }
                else
                {
                    _ = await _customerService.Add(Customer);
                    _messageService.ShowMessage("Se ha creado el cliente correctamente");
                }

                HasChanged = true;
                Close?.Invoke();
            }
            catch (Exception)
            {
                _messageService.ShowErrorMessage($"Ha ocurrido un error al {(CustomerExist() ? "Editar" : "Crear")} al cliente");
            }
        }
        public async Task LoadDependencies()
        {
            try
            {
                CustomerTypes.Clear();
                foreach (CustomerType customerType in await _customerTypeService.GetAll())
                {
                    CustomerTypes.Add(customerType);
                }

                SelectedCustomerType = Customer == null ? CustomerTypes.FirstOrDefault() : Customer.CustomerType;
            }
            catch (Exception)
            {
                _messageService.ShowErrorMessage("Ha ocurrido un error al cargar los tipos de cliente");
            }
        }

        public void SetCustomer(Customer customer)
        {
            _existingCustomer = customer;
            Customer = new Customer()
            {
                Id = customer.Id,
                CustName = customer.CustName,
                Address = customer.Address,
                CustomerTypeId = customer.CustomerTypeId,
                CustomerType = customer.CustomerType
            };
        }

        private void SetExistingCustomerValues()
        {
            _existingCustomer.CustName = Customer.CustName;
            _existingCustomer.Address = Customer.Address;
            _existingCustomer.CustomerTypeId = Customer.CustomerTypeId;
        }


        private bool Validations()
        {
            if (string.IsNullOrWhiteSpace(Customer.CustName))
            {
                _messageService.ShowWarningMessage("El nombre del cliente no puede estár vacío");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Customer.Address))
            {
                _messageService.ShowWarningMessage("La dirección del cliente no puede estár vacía");
                return false;
            }

            if (SelectedCustomerType == null)
            {
                _messageService.ShowWarningMessage("Debe selecionar un tipo de cliente");
                return false;
            }

            return true;
        }
        private bool CustomerExist()
        {
            return Customer.Id > 0;
        }
    }

}
