$(document).ready(function () {
    $('.is_percentage').on('change', function () {
        if ($(this).val() == 2) {
            $(this).closest('tr').find('.amount_percentage').html('Amount:');
        } else {
            $(this).closest('tr').find('.amount_percentage').html('Percentage:');
        }
    });
    $('.main_table_tbody .row_month').on('change', function () {
        var row = $(this).closest('tr');
        var rowBudgetTotal = 0;
        //console.log(row);
        var rowMonths = row.find('.row_month').toArray();
        $.each(rowMonths, function (index, rowMonthInput) {
            if ($(rowMonthInput).val() != "") {
                rowBudgetTotal += eval($(rowMonthInput).val().replace(/\,/g, ''));
            }
        });
        row.find(".row_total").val(rowBudgetTotal);
        updateAllCalculations($(this).closest('table'));
    });
    $('.main_table_tbody').on('click', '.row_split_btn', function () {
        var row = $(this).closest('tr');
        var rowBudget = row.find(".row_total").val().replace(/\,/g, '');
        var rowMonths = row.find(".row_month").toArray();
        var remainder = rowBudget % 12;
        var monthly = eval(rowBudget - remainder) / eval(12);
        $.each(rowMonths, function (index, rowMonthInput) {
            if (index == 11) {
                $(rowMonthInput).val(MathUtils.roundToPrecision(eval(monthly) + eval(remainder), 2));
            } else {
                $(rowMonthInput).val(MathUtils.roundToPrecision(monthly, 2));
            }
        });
        updateAllCalculations($(this).closest('table'));
    });
    $('.selet_all').on('click', function () {
        $(this).closest('.tab-pane').find('.main_table_tbody tr').each(function () {
            $(this).find('.selected').is(":checked") ? $(this).find('.selected').prop('checked', false) : $(this).find('.selected').prop('checked', true);
        });
    });
    $('.proceed_btn').on('click', function () {
        let budgetAmount = $(this).closest('tr').find('.budget_amount').val();
        let is_percentage = $(this).closest('tr').find('.is_percentage').val();
        let type_of_change = $(this).closest('tr').find('.type_of_change').val();
        $(this).closest('.tab-pane').find('.main_table_tbody tr').each(function () {
            if ($(this).find('.selected').is(":checked")) {
                var rowTotal = $(this).find('.row_total').val().replace(/\,/g, '');
                var newTotal = 0;
                if (is_percentage == 1) {
                    //in percentage
                    if (type_of_change == 1) {
                        //increase
                        newTotal = eval(rowTotal) + eval(rowTotal * (budgetAmount / 100));
                    } else {
                        //decrease
                        newTotal = eval(rowTotal) - eval(rowTotal * (budgetAmount / 100));
                    }
                    //$('#current_year_budget').val(Math.ceil(newTotal));
                } else {
                    //in amount
                    if (type_of_change == 1) {
                        //increase
                        newTotal = eval(rowTotal) + eval(budgetAmount);
                    } else {
                        //decrease
                        newTotal = eval(rowTotal) - eval(budgetAmount);
                    }
                    //$('#current_year_budget').val(Math.ceil(newTotal));
                }
                $(this).find('.row_total').val(newTotal);

                $(this).find('.row_month').each(function (index, row_month) {
                    if ($(row_month).val() != 0) {
                        rowMonthValue = $(row_month).val().replace(/\,/g, '');
                        $(row_month).val(eval(rowMonthValue / rowTotal) * newTotal);
                    }
                    //let newValue = $(row_month).val().replace(/\,/g, '');
                });
            }
        });
        updateAllCalculations($(this).closest('.tab-pane').find('.main_table'));
    });
    $('.save_btn').click(function () {
        var bodBudgetDetails = [];
        // global data
        let url = $(this).attr("data-url");
        let account_code = $(this).attr("data-ass-code");
        let account_head = $(this).attr("data-ass-head");
        let budget_type = $(this).attr("data-budget-type");
        let budget_year = $(this).attr("data-budget-year");
        let revision_number = $(this).attr("data-revision-number");

        $(this).closest('table').find('.data_row').each(function () {
            //if ($(this).find('.row_total').val() >= 0) {

            //}
            let row = $(this);
            bodBudgetDetails.push({
                AccountCode: account_code,
                AccountHead: account_head,
                RevisionNo: revision_number,
                BudgetType: budget_type,
                BudgetYear: budget_year,

                BoBudgetDetailId: row.find('.bo_budget_detail_id').val(),
                BudgetGroup: row.find('.budget_group').val(),
                CompanyName: row.find('.company_name').val(),
                Remarks: row.find('.remarks').val(),
                CostCenterId: row.find('.cost_center_id').val().trim(),
                CostCenterCode: row.find('.cost_center_code').val().trim(),
                CostCenterName: row.find('.cost_center_name').text(),

                January: row.find('.row_month_1').val().replace(/\,/g, ''),
                February: row.find('.row_month_2').val().replace(/\,/g, ''),
                March: row.find('.row_month_3').val().replace(/\,/g, ''),
                April: row.find('.row_month_4').val().replace(/\,/g, ''),
                May: row.find('.row_month_5').val().replace(/\,/g, ''),
                June: row.find('.row_month_6').val().replace(/\,/g, ''),
                July: row.find('.row_month_7').val().replace(/\,/g, ''),
                August: row.find('.row_month_8').val().replace(/\,/g, ''),
                September: row.find('.row_month_9').val().replace(/\,/g, ''),
                October: row.find('.row_month_10').val().replace(/\,/g, ''),
                November: row.find('.row_month_11').val().replace(/\,/g, ''),
                December: row.find('.row_month_12').val().replace(/\,/g, ''),

                TotalBudget: row.find('.row_total').val().replace(/\,/g, ''),
                LastYearActual: row.find('.last_year_actual').val().replace(/\,/g, ''),
                IncDecrAmountComparedWithLastYearActual: row.find('.inc_decr_amount_compared_with_last_year_actual').val().replace(/\,/g, ''),
                IncDecrPercentageComparedWithLastYearActual: row.find('.inc_decr_percentage_compared_with_last_year_actual').val().replace(/\,/g, ''),
                LastYearBudgetAmount: row.find('.last_year_budget_amount').val().replace(/\,/g, ''),
                LastLastYearBudgetAmount: row.find('.last_last_year_budget_amount').val().replace(/\,/g, ''),


            });
        });
        console.log(bodBudgetDetails);
        $.post(url, { bodBudgetDetails: bodBudgetDetails }, function (result) {
            if (result == true) {
                Swal.fire(
                    'Success!',
                    'Successfully Saved',
                    'success'
                );
                //location.reload();
            } else {
                Swal.fire(
                    'Failed!',
                    'Failed To Do the operation',
                    'danger'
                );
            }
        });
    });

    $('.reset_btn').click(function () {
        //alert('Clicked');
        let url = $(this).attr("data-url");
        let accountCode = $(this).attr("data-ass-code");
        let budgetType = $(this).attr("data-budget-type");
        let budgetYear = $(this).attr("data-budget-year");
        let versionNo = $(this).attr("data-revision-number");
        Swal.fire({
            title: "Warning!",
            text: "Are you sure? You want reset?",
            type: "warning",
            showCancelButton: true,
            //useRejections: true,
            confirmButtonText: "Reset",
            cancelButtonText: "Cancel"
        }).then(function (result) {
            if (result.value) {
                $.post(url, { budgetYear, budgetType, accountCode, versionNo }, function (result) {
                    location.reload();
                });
            } else if (result.dismiss === 'cancel') {
                //$(location).attr("href", '/purchases');
            }
        });
    });
    //-------------------------Helpers-------------------------
    function updateAllCalculations(table) {
        //updateYield();
        //updateBalance();
        updateTotalMonthlyBudget(table);
        //updateTableRowSerialNumber();
        //the following line should be optimized
        $('.only_number').each(function () {
            $(this).val((new Number($(this).val().replace(/\,/g, ''))).toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ","));
        });
    }

    function updateTotalMonthlyBudget(table) {
        let grand_total = 0;
        for (var i = 1; i <= 12; i++) {
            var total = 0;
            var monthlyBudgets = table.find('.row_month_' + i).toArray();
            $.each(monthlyBudgets, function (index, monthlyBudget) {
                total += eval($(monthlyBudget).val().replace(/\,/g, ''));
            });
            grand_total += total;
            table.find('.row_month_total_' + i).text(total.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ","));
        }
        table.find('.row_month_grand_total').text(grand_total.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ","))
    }
    var MathUtils = {
        roundToPrecision: function (subject, precision) {
            return +((+subject).toFixed(precision));
        },
        addComma: function (value) {
            return 0;
        },
        removeComma: function (value) {
            return value.replace(/\,/g, '');
        }
    };
});