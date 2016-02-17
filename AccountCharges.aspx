<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccountCharges.aspx.cs" Inherits="Pages_AccountCharges" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function doSearch() {
            var searchText = document.getElementById('searchTerm').value;
            var targetTable = document.getElementById('dataTable');
            var targetTableColCount;

            //Loop through table rows
            for (var rowIndex = 0; rowIndex < targetTable.rows.length; rowIndex++) {
                var rowData = '';

                //Get column count from header row
                if (rowIndex == 0) {
                    targetTableColCount = targetTable.rows.item(rowIndex).cells.length;
                    continue; //do not execute further code for header row.
                }

                //Process data rows. (rowIndex >= 1)
                for (var colIndex = 0; colIndex < targetTableColCount; colIndex++) {
                    rowData += targetTable.rows.item(rowIndex).cells.item(colIndex).textContent;
                }

                //If search term is not found in row data
                //then hide the row, else show
                if (rowData.indexOf(searchText) == -1)
                    targetTable.rows.item(rowIndex).style.display = 'none';
                else
                    targetTable.rows.item(rowIndex).style.display = 'table-row';
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="myDiv" runat="server" style="margin-top: 10px; text-transform: uppercase;">
        </div>
    </form>
</body>
</html>
