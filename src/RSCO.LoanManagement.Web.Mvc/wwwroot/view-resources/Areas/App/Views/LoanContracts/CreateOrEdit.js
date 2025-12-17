(function () {
    $(function () {
        var _loanContractsService = abp.services.app.loanContracts;

        var _$loanContractInformationForm = $('form[name=LoanContractInformationsForm]');
        _$loanContractInformationForm.validate();

		
   		
        

        $('.date-picker').daterangepicker({
            singleDatePicker: true,
            locale: abp.localization.currentLanguage.name,
            format: 'L'
        });
      
	    

        function save(successCallback) {
            if (!_$loanContractInformationForm.valid()) {
                return;
            }

            

            var loanContract = _$loanContractInformationForm.serializeFormToObject();
            
			
			
			 abp.ui.setBusy();
			 _loanContractsService.createOrEdit(
				loanContract
			 ).done(function () {
               abp.notify.info(app.localize('SavedSuccessfully'));
               abp.event.trigger('app.createOrEditLoanContractModalSaved');
               
               if(typeof(successCallback)==='function'){
                    successCallback();
               }
			 }).always(function () {
			    abp.ui.clearBusy();
			});
        };
        
        function clearForm(){
            _$loanContractInformationForm[0].reset();
        }
        
        $('#saveBtn').click(function(){
            save(function(){
                window.location="/App/LoanContracts";
            });
        });
        
        $('#saveAndNewBtn').click(function(){
            save(function(){
                if (!$('input[name=id]').val()) {//if it is create page
                   clearForm();
                }
            });
        });
        
        
    });
})();