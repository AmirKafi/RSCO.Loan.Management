(function () {
    $(function () {
        $.fn.dataTable.ext.errMode = 'none';

        var _$loanContractsTable = $('#LoanContractsTable');
        var _loanContractsService = abp.services.app.loanContracts;
		
       var $selectedDate = {
            startDate: null,
            endDate: null
        };

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
            getLoanContracts();
        })
        .on('cancel.daterangepicker', function (ev, picker) {
            $(this).val("");
            $selectedDate.startDate = null;
            getLoanContracts();
        });

        $('.endDate').daterangepicker({
            autoUpdateInput: false,
            singleDatePicker: true,
            locale: abp.localization.currentLanguage.name,
            format: 'L',
        })
        .on("apply.daterangepicker", (ev, picker) => {
            $selectedDate.endDate = picker.startDate;
            getLoanContracts();
        })
        .on('cancel.daterangepicker', function (ev, picker) {
            $(this).val("");
            $selectedDate.endDate = null;
            getLoanContracts();
        });

        var _permissions = {
            create: abp.auth.hasPermission('Pages.LoanContracts.Create'),
            edit: abp.auth.hasPermission('Pages.LoanContracts.Edit'),
            'delete': abp.auth.hasPermission('Pages.LoanContracts.Delete')
        };

         var _createOrEditModal = new app.ModalManager({
                    viewUrl: abp.appPath + 'App/LoanContracts/CreateOrEditModal',
                    scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/LoanContracts/_CreateOrEditModal.js',
                    modalClass: 'CreateOrEditLoanContractModal'
                });
                   

		 var _viewLoanContractModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/LoanContracts/ViewloanContractModal',
            modalClass: 'ViewLoanContractModal'
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

        var dataTable = _$loanContractsTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _loanContractsService.getAll,
                inputFilter: function () {
                    return {
					filter: $('#LoanContractsTableFilter').val(),
					minContractDateFilter:  getDateFilter($('#MinContractDateFilterId')),
					maxContractDateFilter:  getMaxDateFilter($('#MaxContractDateFilterId')),
					minAmountFilter: $('#MinAmountFilterId').val(),
					maxAmountFilter: $('#MaxAmountFilterId').val(),
					summeryFilter: $('#SummeryFilterId').val()
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
                                    _viewLoanContractModal.open({ id: data.record.loanContract.id });
                                }
                        },
						{
                            text: app.localize('Edit'),
                            visible: function () {
                                return _permissions.edit;
                            },
                            action: function (data) {
                            _createOrEditModal.open({ id: data.record.loanContract.id });                                
                            }
                        }, 
						{
                            text: app.localize('Delete'),
                            visible: function () {
                                return _permissions.delete;
                            },
                            action: function (data) {
                                deleteLoanContract(data.record.loanContract);
                            }
                        }]
                    }
                },
					{
						targets: 2,
						 data: "loanContract.contractDate",
						 name: "contractDate" ,
					render: function (contractDate) {
						if (contractDate) {
							return moment(contractDate).format('L');
						}
						return "";
					}
			  
					},
					{
						targets: 3,
						 data: "loanContract.amount",
						 name: "amount"   
					},
					{
						targets: 4,
						 data: "loanContract.summery",
						 name: "summery"   
					},
                    {
                        targets: 5,
                        data: null,
                        name: "borrowerName",
                        orderable: false,
                        responsivePriority: 1,
                        render: function (data, type, row) {
                            return row && row.borrowerName ? row.borrowerName : "";
                        },
                        defaultContent: ""
                    },
                    {
                        targets: 6,
                        data: null,
                        name: "guarantorNames",
                        orderable: false,
                        responsivePriority: 2,
                        render: function (data, type, row) {
                            return row && row.guarantorNames ? row.guarantorNames : "";
                        },
                        defaultContent: ""
                    }
            ]
        });

        function getLoanContracts() {
            dataTable.ajax.reload();
        }

        function deleteLoanContract(loanContract) {
            abp.message.confirm(
                '',
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _loanContractsService.delete({
                            id: loanContract.id
                        }).done(function () {
                            getLoanContracts(true);
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

        $('#CreateNewLoanContractButton').click(function () {
            _createOrEditModal.open();
        });        

		$('#ExportToExcelButton').click(function () {
            _loanContractsService
                .getLoanContractsToExcel({
				filter : $('#LoanContractsTableFilter').val(),
					minContractDateFilter:  getDateFilter($('#MinContractDateFilterId')),
					maxContractDateFilter:  getMaxDateFilter($('#MaxContractDateFilterId')),
					minAmountFilter: $('#MinAmountFilterId').val(),
					maxAmountFilter: $('#MaxAmountFilterId').val(),
					summeryFilter: $('#SummeryFilterId').val()
				})
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        abp.event.on('app.createOrEditLoanContractModalSaved', function () {
            getLoanContracts();
        });

		$('#GetLoanContractsButton').click(function (e) {
            e.preventDefault();
            getLoanContracts();
        });

		$(document).keypress(function(e) {
		  if(e.which === 13) {
			getLoanContracts();
		  }
		});

        $('.reload-on-change').change(function(e) {
			getLoanContracts();
		});

        $('.reload-on-keyup').keyup(function(e) {
			getLoanContracts();
		});

        $('#btn-reset-filters').click(function (e) {
            $('.reload-on-change,.reload-on-keyup,#MyEntsTableFilter').val('');
            getLoanContracts();
        });
		
		
		

    });
})();
