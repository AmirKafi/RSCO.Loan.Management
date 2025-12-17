(function () {
    $(function () {

        var _$peopleTable = $('#PeopleTable');
        var _peopleService = abp.services.app.people;
		
       var $selectedDate = {
            startDate: null,
            endDate: null,
        }

        $('.date-picker').on('apply.daterangepicker', function (ev, picker) {
            $(this).val(picker.startDate.format('MM/DD/YYYY'));
        });

        $('.startDate').daterangepicker({
            autoUpdateInput: false,
            singleDatePicker: true,
            locale: abp.localization.currentLanguage.name,
            format: 'L',
        })
        .on("apply.daterangepicker", (ev, picker) => {
            $selectedDate.startDate = picker.startDate;
            getPeople();
        })
        .on('cancel.daterangepicker', function (ev, picker) {
            $(this).val("");
            $selectedDate.startDate = null;
            getPeople();
        });

        $('.endDate').daterangepicker({
            autoUpdateInput: false,
            singleDatePicker: true,
            locale: abp.localization.currentLanguage.name,
            format: 'L',
        })
        .on("apply.daterangepicker", (ev, picker) => {
            $selectedDate.endDate = picker.startDate;
            getPeople();
        })
        .on('cancel.daterangepicker', function (ev, picker) {
            $(this).val("");
            $selectedDate.endDate = null;
            getPeople();
        });

        var _permissions = {
            create: abp.auth.hasPermission('Pages.People.Create'),
            edit: abp.auth.hasPermission('Pages.People.Edit'),
            'delete': abp.auth.hasPermission('Pages.People.Delete')
        };

               

		 var _viewPersonModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/People/ViewpersonModal',
            modalClass: 'ViewPersonModal'
        });

		
		

        var getDateFilter = function (element) {
            if ($selectedDate.startDate == null) {
                return null;
            }
            return $selectedDate.startDate.format("YYYY-MM-DDT00:00:00Z"); 
        }
        
        var getMaxDateFilter = function (element) {
            if ($selectedDate.endDate == null) {
                return null;
            }
            return $selectedDate.endDate.format("YYYY-MM-DDT23:59:59Z"); 
        }

        var dataTable = _$peopleTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _peopleService.getAll,
                inputFilter: function () {
                    return {
					filter: $('#PeopleTableFilter').val(),
					firstNameFilter: $('#FirstNameFilterId').val(),
					lastNameFilter: $('#LastNameFilterId').val()
                    };
                }
            },
            columnDefs: [
                {
                    className: 'control responsive',
                    orderable: false,
                    render: function () {
                        return '';
                    },
                    targets: 0
                },
                {
                    width: 120,
                    targets: 1,
                    data: null,
                    orderable: false,
                    autoWidth: false,
                    defaultContent: '',
                    rowAction: {
                        cssClass: 'btn btn-brand dropdown-toggle',
                        text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                        items: [
						{
                                text: app.localize('View'),
                                action: function (data) {
                                    window.location="/App/People/ViewPerson/" + data.record.person.id;
                                }
                        },
						{
                            text: app.localize('Edit'),
                            visible: function () {
                                return _permissions.edit;
                            },
                            action: function (data) {
                            window.location="/App/People/CreateOrEdit/" + data.record.person.id;                                
                            }
                        }, 
						{
                            text: app.localize('Delete'),
                            visible: function () {
                                return _permissions.delete;
                            },
                            action: function (data) {
                                deletePerson(data.record.person);
                            }
                        }]
                    }
                },
					{
						targets: 2,
						 data: "person.firstName",
						 name: "firstName"   
					},
					{
						targets: 3,
						 data: "person.lastName",
						 name: "lastName"   
					}
            ]
        });

        function getPeople() {
            dataTable.ajax.reload();
        }

        function deletePerson(person) {
            abp.message.confirm(
                '',
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _peopleService.delete({
                            id: person.id
                        }).done(function () {
                            getPeople(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        }

		$('#ShowAdvancedFiltersSpan').click(function () {
            $('#ShowAdvancedFiltersSpan').hide();
            $('#HideAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideDown();
        });

        $('#HideAdvancedFiltersSpan').click(function () {
            $('#HideAdvancedFiltersSpan').hide();
            $('#ShowAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideUp();
        });

                

		$('#ExportToExcelButton').click(function () {
            _peopleService
                .getPeopleToExcel({
				filter : $('#PeopleTableFilter').val(),
					firstNameFilter: $('#FirstNameFilterId').val(),
					lastNameFilter: $('#LastNameFilterId').val()
				})
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        abp.event.on('app.createOrEditPersonModalSaved', function () {
            getPeople();
        });

		$('#GetPeopleButton').click(function (e) {
            e.preventDefault();
            getPeople();
        });

		$(document).keypress(function(e) {
		  if(e.which === 13) {
			getPeople();
		  }
		});

        $('.reload-on-change').change(function(e) {
			getPeople();
		});

        $('.reload-on-keyup').keyup(function(e) {
			getPeople();
		});

        $('#btn-reset-filters').click(function (e) {
            $('.reload-on-change,.reload-on-keyup,#MyEntsTableFilter').val('');
            getPeople();
        });
		
		
		

    });
})();
