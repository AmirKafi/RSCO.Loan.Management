(function () {
    $(function () {
        var _peopleService = abp.services.app.people;

        var _$personInformationForm = $('form[name=PersonInformationsForm]');
        _$personInformationForm.validate();

		
   		
        

        $('.date-picker').daterangepicker({
            singleDatePicker: true,
            locale: abp.localization.currentLanguage.name,
            format: 'L'
        });
      
	    

        function save(successCallback) {
            if (!_$personInformationForm.valid()) {
                return;
            }

            

            var person = _$personInformationForm.serializeFormToObject();
            
			
			
			 abp.ui.setBusy();
			 _peopleService.createOrEdit(
				person
			 ).done(function () {
               abp.notify.info(app.localize('SavedSuccessfully'));
               abp.event.trigger('app.createOrEditPersonModalSaved');
               
               if(typeof(successCallback)==='function'){
                    successCallback();
               }
			 }).always(function () {
			    abp.ui.clearBusy();
			});
        };
        
        function clearForm(){
            _$personInformationForm[0].reset();
        }
        
        $('#saveBtn').click(function(){
            save(function(){
                window.location="/App/People";
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