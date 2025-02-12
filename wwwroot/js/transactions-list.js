/**
 * Transactions CRUD JS
 */

'use strict';

// Transactions DataTable initialization
$(document).ready(function () {
  let borderColor, bodyBg, headingColor;

  if (isDarkStyle) {
    borderColor = config.colors_dark.borderColor;
    bodyBg = config.colors_dark.bodyBg;
    headingColor = config.colors_dark.headingColor;
  } else {
    borderColor = config.colors.borderColor;
    bodyBg = config.colors.bodyBg;
    headingColor = config.colors.headingColor;
  }

  var toastElements = document.querySelectorAll('.toast');

  if (toastElements) {
    toastElements.forEach(function (element) {
      var toast = new bootstrap.Toast(element);
      toast.show();
    });
  }

  // Transactions List DataTable Initialization (For Transactions CRUD Page)
  $('#transactionsTable').DataTable({
    order: [[1, 'desc']],
    displayLength: 7,
    dom:
      // Datatable DOM positioning
      '<"mx-6 d-flex flex-wrap flex-column flex-md-row gap-sm-2 pb-6 py-sm-0"' +
      '<"d-flex align-items-center me-auto mb-n6 mb-md-0"l>' +
      '<"dt-action-buttons text-xl-end text-lg-start text-md-end text-start d-flex flex-sm-row align-items-center justify-content-md-end gap-sm-2 ms-n2 ms-md-2 flex-wrap flex-sm-nowrap"fB>' +
      '>t' +
      '<"row"' +
      '<"col-sm-12 col-md-6"i>' +
      '<"col-sm-12 col-md-6 pb-6 ps-0"p>' +
      '>',
    lengthMenu: [7, 10, 15, 20],
    language: {
      searchPlaceholder: 'Search..',
      search: '',
      lengthMenu: '_MENU_'
    },
    // Buttons with Dropdown
    buttons: [
      {
        extend: 'collection',
        className: 'btn btn-label-secondary dropdown-toggle shadow-none ms-2 me-0 me-md-4 mx-sm-2',
        text: '<i class="bx bx-export me-2 align-bottom"></i>Export',
        buttons: [
          {
            extend: 'print',
            title: 'Transactions Data',
            text: '<i class="bx bx-printer me-2" ></i>Print',
            className: 'dropdown-item',
            customize: function (win) {
              //customize print view for dark
              $(win.document.body)
                .css('color', config.colors.headingColor)
                .css('border-color', config.colors.borderColor)
                .css('background-color', config.colors.body);

              $(win.document.body)
                .find('table')
                .addClass('compact')
                .css('color', 'inherit')
                .css('border-color', 'inherit')
                .css('background-color', 'inherit');

              // Center the title "Transactions Data"
              $(win.document.body).find('h1').css('text-align', 'center');
            },
            exportOptions: {
              columns: [1, 2, 3, 4, 5, 6]
            }
          },
          {
            extend: 'csv',
            title: 'Transactions',
            text: '<i class="bx bx-file me-2" ></i>Csv',
            className: 'dropdown-item',
            exportOptions: {
              columns: [1, 2, 3, 4, 5, 6]
            }
          },
          {
            extend: 'excel',
            title: 'Transactions',
            text: '<i class="bx bxs-file-export me-1"></i>Excel',
            className: 'dropdown-item',
            exportOptions: {
              columns: [1, 2, 3, 4, 5, 6]
            }
          },
          {
            extend: 'pdf',
            title: 'Transactions',
            text: '<i class="bx bxs-file-pdf me-2"></i>Pdf',
            className: 'dropdown-item',
            exportOptions: {
              columns: [1, 2, 3, 4, 5, 6]
            }
          },
          {
            extend: 'copy',
            title: 'Transactions',
            text: '<i class="bx bx-copy me-2" ></i>Copy',
            className: 'dropdown-item',
            exportOptions: {
              columns: [1, 2, 3, 4, 5, 6]
            }
          }
        ]
      },
      {
        // For Create Transactions Button (Add New Transactions)
        text: '<i class="bx bx-plus me-0 me-md-2 align-center"></i><span class="d-none d-md-inline-block">Add Transaction</span>',
        className: 'add-new btn btn-primary',
        action: function (e, dt, button, config) {
          window.location.href = '/Transactions/Add';
        }
      }
    ],
    responsive: true,
    // For responsive popup
    rowReorder: {
      selector: 'td:nth-child(2)'
    },
    // For responsive popup button and responsive priority for transactions name
    columnDefs: [
      {
        // For Responsive Popup Button (plus icon)
        className: 'control',
        searchable: false,
        orderable: false,
        responsivePriority: 2,
        targets: 0,
        render: function (data, type, full, meta) {
          return '';
        }
      },
      {
        // For Id
        targets: 1,
        responsivePriority: 4
      },
      {
        // For Transactions Name
        targets: 2,
        responsivePriority: 3
      },
      {
        // For Transactions Date
        targets: 3,
        responsivePriority: 9
      },
      {
        // For Due Date
        targets: 4,
        responsivePriority: 5
      },
      {
        // For Total Amount
        targets: 5,
        responsivePriority: 7
      },
      {
        // For Status
        targets: 6,
        responsivePriority: 8
      },
      {
        // For Actions
        targets: -1,
        searchable: false,
        orderable: false,
        responsivePriority: 1
      }
    ],
    language: {
      paginate: {
        next: '<i class="bx bx-chevron-right bx-18px"></i>',
        previous: '<i class="bx bx-chevron-left bx-18px"></i>'
      }
    },
    responsive: {
      details: {
        display: $.fn.dataTable.Responsive.display.modal({
          header: function (row) {
            var data = row.data();
            return 'Details of ' + data[2];
          }
        }),
        type: 'column',
        renderer: function (api, rowIdx, columns) {
          var data = $.map(columns, function (col, i) {
            // Exclude the last column (Action)
            if (i < columns.length - 1) {
              return col.title !== ''
                ? '<tr data-dt-row="' +
                    col.rowIndex +
                    '" data-dt-column="' +
                    col.columnIndex +
                    '">' +
                    '<td>' +
                    col.title +
                    ':' +
                    '</td> ' +
                    '<td>' +
                    col.data +
                    '</td>' +
                    '</tr>'
                : '';
            }
            return '';
          }).join('');

          return data ? $('<table class="table"/><tbody />').append(data) : false;
        }
      }
    }
  });
});

// Filter Form styles to default size after DataTable initialization
setTimeout(() => {
  $('.dataTables_filter .form-control').removeClass('form-control-sm');
  $('.dataTables_filter .form-control').addClass('ms-2');
  $('.dataTables_length .form-select').removeClass('form-select-sm');
  $('.dt-buttons').addClass('d-flex align-items-center gap-4 gap-md-0');
  $('#transactionsTable_length').addClass('mx-n2');
}, 300);
