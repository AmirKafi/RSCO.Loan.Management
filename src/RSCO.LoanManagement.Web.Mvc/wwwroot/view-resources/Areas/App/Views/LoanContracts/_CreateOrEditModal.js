(function ($) {
    app.modals.CreateOrEditLoanContractModal = function () {

        var _loanContractsService = abp.services.app.loanContracts;

        var _modalManager;
        var _$loanContractInformationForm = null;

		
		
		

        this.init = function (modalManager) {
            _modalManager = modalManager;

			var modal = _modalManager.getModal();
            modal.find('.date-picker').daterangepicker({
                singleDatePicker: true,
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });

            modal.find('.select2').select2({
                width: '100%',
                dropdownParent: modal
            });

            var $borrowerSelect = modal.find('#BorrowerId');
            var $guarantorSelect = modal.find('#GuarantorIds');

            function handleBorrowerChange() {
                var borrowerId = $borrowerSelect.val();
                
                // Enable all options in guarantor select
                $guarantorSelect.find('option').prop('disabled', false);

                if (borrowerId) {
                    // Disable the selected borrower in guarantor select
                    var $option = $guarantorSelect.find('option[value="' + borrowerId + '"]');
                    $option.prop('disabled', true);

                    // If the borrower is currently selected as a guarantor, deselect them
                    var currentGuarantors = $guarantorSelect.val();
                    if (currentGuarantors && Array.isArray(currentGuarantors) && currentGuarantors.includes(borrowerId)) {
                        var newGuarantors = currentGuarantors.filter(id => id !== borrowerId);
                        $guarantorSelect.val(newGuarantors).trigger('change');
                    }
                }
            }

            $borrowerSelect.change(handleBorrowerChange);
            
            // Trigger initially to handle edit mode
            handleBorrowerChange();

            _$loanContractInformationForm = _modalManager.getModal().find('form[name=LoanContractInformationsForm]');
            _$loanContractInformationForm.validate();
        };

		  

        this.save = function () {
            if (!_$loanContractInformationForm.valid()) {
                return;
            }

            

            var loanContract = _$loanContractInformationForm.serializeFormToObject();
            
            // Ensure guarantorIds is an array
            if (loanContract.guarantorIds && !Array.isArray(loanContract.guarantorIds)) {
                loanContract.guarantorIds = [loanContract.guarantorIds];
            }
            
			
			 _modalManager.setBusy(true);
			 _loanContractsService.createOrEdit(
				loanContract
			 ).done(function () {
               abp.notify.info(app.localize('SavedSuccessfully'));
               _modalManager.close();
               abp.event.trigger('app.createOrEditLoanContractModalSaved');
			 }).always(function () {
               _modalManager.setBusy(false);
			});
        };
        
        
    };
})(jQuery);