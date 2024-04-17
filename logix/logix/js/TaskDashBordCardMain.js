//// Function to fetch data from the API
//async function fetchData() {
//    try {
//        const response = await fetch('https://jsonplaceholder.typicode.com/posts');
//        console.log(response);
//        const data = await response.json();
//        console.log(data)
//        return data;
//    } catch (error) {
//        console.error('Error fetching data:', error);
//    }
//}

//// Function to render data in cards
//async function renderData() {
//    const dynamic = document.querySelector('.dynamic');
//    const data = await fetchData();

//    if (!data) {
//        return;
//    }

//    data.forEach(item => {
//        const card = document.createElement('div');
//        card.classList.add('card');

//        const title = document.createElement('a');
//        title.textContent = "Google";
//        title.setAttribute("href", "http://triotrak.virtue.copperhawk.tech/");

//        const body = document.createElement('p');
//        body.textContent = item.body;
//        const img = document.createElement('img');

//        card.appendChild(title);
//        card.appendChild(body);
//        card.appendChild(img);
//        dynamic.appendChild(card);
//    });
//}

//// Call the renderData function to display data
//renderData();



//function dynamiccard() {
//	let j = 30
//	let parent = document.querySelector('.dynamic');

//	for (let i = 1; i <= j; i++) {

//		// dynamically creating div
//		let div = document.createElement('div');
//		div.className = "card"
//		div.setAttribute('id', "div" + i);


//		// dynamically creating span(1)
//		let span1 = document.createElement('a');
//		span1.setAttribute('id', i + "span1");
//		span1.textContent = "Freight Forwarding Task" + i;
//		span1.className = "span1"

//		// dynamically creating span(2)
//		let span2 = document.createElement('a');
//		span2.setAttribute('id', i + "span2");
//		span2.textContent = 100 + i;
//		span2.className = "span2"


//		// dynamically creating span(3)
//		let span3 = document.createElement('a');
//		span3.setAttribute('id', i + "span3");
//		span3.textContent = 1000 + i;
//		span3.className = "span3"

//		// dynamically creating image
//		let img = document.createElement('img');
//		img.className = "img";
//		img.setAttribute('id', i + "img");
//		img.src = "../Theme/assets/img/dashboard/jobs.png"


//		parent.appendChild(div);
//		div.appendChild(span1);
//		div.appendChild(span2);
//		div.appendChild(span3);
//		div.appendChild(img);
//	}
//}



async function GetEmpolyeeJson() {


	$(document).ready(function () {
		$(function () {

			$.ajax({
				type: 'POST',
				dataType: 'json',
				contentType: 'application/json',
				url: '../TaskDetailsDashMain.aspx/GetEmpolyeeJsonTak',
				data: '{}',
				success:
					function (response) {

						console.log(response.data);
						//const obj = JSON.parse(response);
						//const data = obj;
						//return data;
						dynamiccard(response.d);
					},

				error: function () {
					alert("Error loading data! Please try again.");
				}
			});
		})
	})
}



function GetEmpolyeeJsonForTask() {
	//document.addEventListener('DOMContentLoaded', function GetEmpolyeeJsonForTask() {


	var txtcustomer = (document.querySelector('input[name=hf_customerid]').value != '')
		? document.querySelector('input[name=hf_customerid]').value : '1';





	var txtSalesPerson = (document.querySelector('input[name=hdf_salesperson]').value != '')
		? document.querySelector('input[name=hdf_salesperson]').value : '1';

	var txtSalesPerson1 = (document.querySelector('input[name=txtSalesPerson]').value != '')
		? document.querySelector('input[name=txtSalesPerson]').value : '1';


	if (txtSalesPerson1 != "1") {
		txtSalesPerson1.Text = '';
		txtSalesPerson1.value = '';
		hdf_salesperson.value = '1';
		var textBox = document.getElementById('<%= txtSalesPerson.ClientID %>');
		document.getElementById('txtSalesPerson').value = "";
		//textBox.value = '';
		getDataAndUpdateList();
		document.getElementById('sp').style.display = 'none';

	}


	$(document).ready(function () {
		$(function () {

			$.ajax({
				type: 'POST',
				dataType: 'json',
				contentType: 'application/json',
				url: '../TaskDetailsDashMain.aspx/GetEmpolyeeJson',
				data: "{ 'txtcustomer': '" + txtcustomer + "','txtSalesPerson':'" + txtSalesPerson + "'}",
				success:
					function (response) {

						console.log(response.data);
						//const obj = JSON.parse(response);
						//const data = obj;
						//return data;
						dynamiccard(response.d);
					},

				error: function () {
					alert("Error loading data! Please try again.");
				}
			});
		})
	})
}
function getDataAndUpdateList() {

	var inputText = (document.querySelector('input[name=hdf_salesperson]').value != '') ?
		document.querySelector('input[name=hdf_salesperson]').value : '1';

	//var txtcustomer = (document.querySelector('input[name=hf_customerid]').value != '')
	//	? document.querySelector('input[name=hf_customerid]').value : '1';

	//var txtcustomer1 = (document.querySelector('input[name=txtcustomer]').value != '')
	//	? document.querySelector('input[name=txtcustomer]').value : '1';





	/*var inputText = $('#hdf_salesperson').val();*/
	$.ajax({
		type: "POST",
		url: "TaskDetailsDashMain.aspx/GetSalesPersonCustomer",
		data: JSON.stringify({ input: inputText }),
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: function (response) {
			var dataList = response.d;
			sessionStorage.setItem("rowValues", JSON.stringify(dataList));
			var listContainer = $('#listContainer');
			listContainer.empty(); // Clear previous items


			if (dataList.length != 0) {
				/*var listItem1 = $('<li>');*/
				var selectedCustomerIds = []; // Array to store selected customer IDs

				var selectedCustomerIdsuncheck = [];
				var selectAllCheckbox = document.createElement('input');
				selectAllCheckbox.setAttribute('type', 'checkbox');
				selectAllCheckbox.classList.add('select-all');
				selectAllCheckbox.Text = "Select";
				//var label = document.createElement('label');
				//listItem1.appendChild(selectAllCheckbox);
				//listItem1.appendChild(document.createTextNode(' Select All'));
				//document.getElementById('<%= sp.ClientID %>').style.display = 'block';

				document.getElementById('sp').style.display = 'inherit';


				selectAllCheckbox.addEventListener('change', function () {
					var isChecked = this.checked;
					var checkboxes = listContainer.find('input[type="checkbox"]');
					for (var i = 0; i < 1; i++) {
						checkboxes[i].checked = isChecked;
						var customerId = checkboxes[i].parentNode.getAttribute('customerId');
						var cus = $(this).parent().data('customerId');
						if (isChecked) {
							const rowValues = JSON.parse(sessionStorage.getItem("rowValues"));

							// Do something with the row values.
							for (let i = 0; i < rowValues.length; i++) {
								if (Array.isArray(rowValues) && rowValues.length > 0) {
									// Accessing Customerid property of the first object in rowValues array
									const customerId = rowValues[i].Customerid;

									selectedCustomerIds.push(customerId);

									// Do something with customerId
									/*console.log("Customer ID:", customerId);*/
								}
							}
							//selectedCustomerIds.push(customerId);
						} else {
							var index = selectedCustomerIds.indexOf(customerId);
							if (index !== -1) {
								selectedCustomerIds.splice(index, 1);
							}
						}
					}
					callWebMethod(selectedCustomerIds);
					selectedCustomerIds = [];
				});
				listContainer.prepend(selectAllCheckbox);
				$.each(dataList, function (index, item) {
					var sessionArray = [];
					sessionStorage.setItem('sessionArray', JSON.stringify(sessionArray));
					var listItem = $('<li>');
					var isChecked1 = $(this).is(selectAllCheckbox);
					if (isChecked1) {
						var checkbox = $('<input>').attr('type', 'checkbox').attr('value', item.Customername).attr('checked', 'checked');
					}
					else {
						var checkbox = $('<input>').attr('type', 'checkbox').attr('value', item.Customername);
					}
					checkbox.change(function () {

						var isChecked = $(this).is(':checked');
						var customerId = $(this).parent().data('customerId');
						var sessionArray = JSON.parse(sessionStorage.getItem('sessionArray')) || [];
						if (isChecked) {

							selectedCustomerIds.push(customerId);

							var sessionArray = JSON.parse(sessionStorage.getItem('sessionArray'));

							for (var j = 0; j < sessionArray.length; j++) {


								if (sessionArray[j] == customerId) {

									sessionArray[j] = 0;
									sessionStorage.setItem('sessionArray', JSON.stringify(sessionArray));
								}

							}
							callWebMethod(selectedCustomerIds);
							// Add customer ID to the array when checkbox is checked
						}


						else {

							for (var s = 0; s < selectedCustomerIds.length; s++) {

								if (selectedCustomerIds[s] == customerId) {
									selectedCustomerIds[s] = 0;

								}
							}

							// Push elements into the sessionArray
							sessionArray.push(customerId);
							/*sessionArray.push(customerId);*/
							// Add more elements as needed

							// Store the updated array back into sessionStorage
							sessionStorage.setItem('sessionArray', JSON.stringify(sessionArray));
							var sessionArray = JSON.parse(sessionStorage.getItem('sessionArray'));


							var checkboxes1 = listContainer.find('input[type="checkbox"]');

							for (var i = 0; i < checkboxes1.length - 1; i++) {
								var counts = "1";
								var customerId4 = 0;

								for (var j = 0; j < sessionArray.length; j++) {





									const rowValues = JSON.parse(sessionStorage.getItem("rowValues"));
									if (Array.isArray(rowValues) && rowValues.length > 0) {

										const customerId3 = rowValues[i].Customerid;
										customerId4 = customerId3;
										var x = sessionArray[j];

										if (x == customerId3) {

											counts = "0";



										}

										// Do something with customerId
										/*console.log("Customer ID:", customerId);*/
									}

									//var isChecked = $(this).is(':checked');
									//var customerId = $(this).parent().data('customerId');
									//var customerId1 = $(this).parent().data('customerId');
									//selectedCustomerIds.push(customerId1);
									// At least one checkbox is checked
								}
								if (counts != "0") {
									selectedCustomerIdsuncheck.push(customerId4);
								}
							}


							selectAllCheckbox.checked = false;
							//var index = selectedCustomerIds.indexOf(customerId);
							//if (index !== -1) {
							//	selectedCustomerIds.splice(index, 1); // Remove customer ID from the array when checkbox is unchecked
							//}

							callWebMethod(selectedCustomerIdsuncheck);
							selectedCustomerIdsuncheck = [];
						}

						// Call web method with the array of selected customer IDs
					});
					var sessionArray = [];
					sessionStorage.setItem('sessionArray', JSON.stringify(sessionArray));


					listItem.append(checkbox);
					listItem.append(item.Customername);
					listItem.data('customerId', item.Customerid);
					listContainer.append(listItem);
				});
			}
			else if (inputText != 1 & dataList.length == 0) {
				document.getElementById('sp').style.display = 'none';
				alert("No Data For The SalesPerson / Assigne");
			}
		},
		error: function (xhr, status, error) {
			console.error(error);
		}
	});
}









function callWebMethod(selectedItem) {
	// Call your web method here with the selected item
	var txtcustomer = "0";



	var ddl_voutype = document.getElementById('ddl_voutype');

	var ddl_branch = document.getElementById('ddl_branch');

	// Get the selected option
	var voutype = ddl_voutype.options[ddl_voutype.selectedIndex];

	// Get the value of the selected option
	var Voutypevalue = voutype.value;



	//var branch = ddl_branch.options[ddl_branch.selectedIndex];

	//// Get the value of the selected option
	//var branchvalue = branch.value;

	const rowValues = JSON.parse(sessionStorage.getItem("sessionArray1"));
	let x = rowValues.length;
	var branchvalue;
	if (x == 7) {
		branchvalue = "0";

	}



	var txtSalesPerson = (document.querySelector('input[name=hdf_salesperson]').value != '')
		? document.querySelector('input[name=hdf_salesperson]').value : '0';






	var txtSalesPerson = (document.querySelector('input[name=hdf_salesperson]').value != '')
		? document.querySelector('input[name=hdf_salesperson]').value : '0';



	$(document).ready(function () {
		$(function () {

			$.ajax({
				type: 'POST',
				dataType: 'json',
				contentType: 'application/json',
				url: '../TaskDetailsDashMain.aspx/GetTaskbasedCard4all',
				data: "{'bid':'" + branchvalue + "','voutype':'" + Voutypevalue + "','customerid':'" + txtcustomer + "','empid':'" + txtSalesPerson + "'}",
				success:
					function (response) {

						console.log(response.data);
						//const obj = JSON.parse(response);
						//const data = obj;
						//return data;
						dynamiccard(response.d);

					},

				error: function () {
					alert("Error loading data! Please try again.");
				}
			});
		})
	})
}



async function dynamiccard(data) {




	var updatedContent = "";

	// Get the div element
	var divElement = document.getElementById("card_parent");

	// Replace the content of the div with the updated content
	divElement.innerHTML = updatedContent;

	let parent = document.querySelector('.dynamic');


	if (data.length > 0) {

		for (let i = 0; i <= data.length; i++) {

			// dynamically creating div
			let div = document.createElement('div');
			div.className = "card box-shadow"
			div.setAttribute('id', "div" + i);


			// dynamically creating span(1)
			let span1 = document.createElement('a');
			span1.setAttribute('id', i + "span1");
			span1.textContent = [data[i].Tasks];
			span1.className = "span1"
			span1.addEventListener('click', () => handleSpanClick(data[i].TaskDetailId, data[i].Tasks, data[i].Taskid));

			// dynamically creating span(2)
			let span2 = document.createElement('a');
			span2.setAttribute('id', i + "span2");
			span2.textContent = [data[i].Taskid];
			span2.className = "span2"
			span2.addEventListener('click', () => handleSpanClick(data[i].TaskDetailId, data[i].Tasks, data[i].Taskid));
			// Add click event for span2


			// dynamically creating span(3)
			let span3 = document.createElement('a');
			span3.setAttribute('id', i + "span3");
			span3.textContent = [data[i].counts];
			span3.className = "span3"
			span3.addEventListener('click', () => handleSpanClick(data[i].TaskDetailId, data[i].Tasks, data[i].Taskid));

			// dynamically creating image
			let img = document.createElement('img');
			img.className = "img";
			img.setAttribute('id', i + "img");
			var icon = [data[i].Icon].toString();
			//img.src = "../Theme/assets/img/dashboard/jobs.png"
			img.src = icon;
			img.addEventListener('click', () => handleSpanClick(data[i].TaskDetailId, data[i].Tasks, data[i].Taskid));



			div.appendChild(span1);
			div.appendChild(span2);
			div.appendChild(span3);
			div.appendChild(img);
			div.addEventListener('click', () => handleSpanClick(data[i].TaskDetailId, data[i].Tasks, data[i].Taskid));
			parent.appendChild(div);
		}
	}

}
function handleSpanClick(value, taskName, Taskid) {
	var queryString = 'taskid=' + taskName; // Construct query string parameter
	var branchid = JSON.parse(sessionStorage.getItem("sessionArray"));
	var voutype = JSON.parse(sessionStorage.getItem("sessionArrayvouchar"));
	var customer = JSON.parse(sessionStorage.getItem("sessioncustomer"));
	var Salesprson = JSON.parse(sessionStorage.getItem("sessionsalesperson"));
	var TaskValue = 'branch=' + branchid + '&taskid=' + taskName + '&voutype=' + voutype;





	window.location.href = '../CRM/Customersupport4AllTaskDashBord.aspx?' + TaskValue;

}



function ClearEmployeeTask() {
	// Call your web method here with the selected item
	var txtcustomer = "1";







	var txtSalesPerson = "1";



	$(document).ready(function () {
		$(function () {

			$.ajax({
				type: 'POST',
				dataType: 'json',
				contentType: 'application/json',
				url: '../TaskDetailsDashMain.aspx/GetEmpolyeeJson',
				data: "{ 'txtcustomer': '" + txtcustomer + "','txtSalesPerson':'" + txtSalesPerson + "'}",
				success:
					function (response) {

						console.log(response.data);
						//const obj = JSON.parse(response);
						//const data = obj;
						//return data;
						dynamiccard(response.d);

					},

				error: function () {
					alert("Error loading data! Please try again.");
				}
			});
		})
	})



}
function branchddlChanged() {
	// Get the dropdown element
	var dropdown = document.getElementById('ddl_branch');

	// Get the selected option
	var selectedOption = dropdown.options[dropdown.selectedIndex];

	// Get the value of the selected option
	var selectedValue = selectedOption.value;

	// Output the selected value
	$(document).ready(function () {
		$(function () {

			$.ajax({
				type: 'POST',
				dataType: 'json',
				contentType: 'application/json',
				url: '../TaskDetailsDashMain.aspx/GetTaskbasedCard4OpenFirst',
				data: "{'bid':'" + selectedValue + "'}",
				success:
					function (response) {

						console.log(response.data);
						//const obj = JSON.parse(response);
						//const data = obj;
						//return data;
						dynamiccard(response.d);

					},

				error: function () {
					alert("Error loading data! Please try again.");
				}
			});
		})
	})


}


function voutypeddlChanged() {
	// Get the dropdown element
	var ddl_voutype = document.getElementById('ddl_voutype');

	var ddl_branch = document.getElementById('ddl_branch');

	// Get the selected option
	var voutype = ddl_voutype.options[ddl_voutype.selectedIndex];

	// Get the value of the selected option
	var Voutypevalue = voutype.value;



	var branch = ddl_branch.options[ddl_branch.selectedIndex];

	// Get the value of the selected option
	var branchvalue = branch.value;



	var txtSalesPerson = (document.querySelector('input[name=hdf_salesperson]').value != '')
		? document.querySelector('input[name=hdf_salesperson]').value : '0';


	var txtcustomer = (document.querySelector('input[name=hf_customerid]').value != '')
		? document.querySelector('input[name=hf_customerid]').value : '0';

	// Output the selected value
	$(document).ready(function () {
		$(function () {

			$.ajax({
				type: 'POST',
				dataType: 'json',
				contentType: 'application/json',
				url: '../TaskDetailsDashMain.aspx/GetTaskbasedCard4all',
				data: "{'bid':'" + branchvalue + "','voutype':'" + Voutypevalue + "','customerid':'" + txtcustomer + "','empid':'" + txtSalesPerson + "'}",
				success:
					function (response) {

						console.log(response.data);
						//const obj = JSON.parse(response);
						//const data = obj;
						//return data;
						dynamiccard(response.d);

					},

				error: function () {
					alert("Error loading data! Please try again.");
				}
			});
		})
	})


}

function branchlistChanged() {

	$(document).ready(function () {
		$.ajax({
			type: "POST",
			url: "TaskDetailsDashMain.aspx/GetBrachDetails",
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function (response) {
				var dataList = response.d;
				sessionStorage.setItem("rowValues", JSON.stringify(dataList));
				var listContainer = $('#listContainerbranch');
				listContainer.empty(); // Clear previous items


				if (dataList.length != 0) {
					/*var listItem1 = $('<li>');*/
					var selectedCustomerIds = []; // Array to store selected customer IDs
					var selectedCustomerIdsuncheck = [];
					var sessionbranch = [];

					var sessionArray = JSON.parse(sessionStorage.getItem('sessionArray')) || [];
					var selectAllCheckBoxbranch = document.createElement('input');
					selectAllCheckBoxbranch.setAttribute('type', 'checkbox');
					selectAllCheckBoxbranch.setAttribute('checked', 'checked')
					selectAllCheckBoxbranch.classList.add('select-all');
					selectAllCheckBoxbranch.Text = "Select";
					//var label = document.createElement('label');
					//listItem1.appendChild(selectAllCheckbox);
					//listItem1.appendChild(document.createTextNode(' Select All'));
					//document.getElementById('<%= sp.ClientID %>').style.display = 'block';

					document.getElementById('branch').style.display = 'inherit';



					var isChecked = selectAllCheckBoxbranch.checked;
					var checkboxes = listContainer.find('input[type="checkbox"]');





					if (isChecked) {
						const rowValues = JSON.parse(sessionStorage.getItem("rowValues"));

						// Do something with the row values.
						for (let i = 0; i < rowValues.length; i++) {
							if (Array.isArray(rowValues) && rowValues.length > 0) {
								// Accessing Customerid property of the first object in rowValues array
								const customerId = rowValues[i].Portid;

								selectedCustomerIds.push(customerId);

								// Do something with customerId
								/*console.log("Customer ID:", customerId);*/
							}
						}

						sessionStorage.setItem('sessionArray', JSON.stringify(selectedCustomerIds));
						selectedCustomerIds = [];
						FinalFunTaskDashBord();



					}



					selectAllCheckBoxbranch.addEventListener('change', function () {
						const rowValues = JSON.parse(sessionStorage.getItem("rowValues"));
						const rv = JSON.parse(sessionStorage.getItem("sessionArrayvouchar"));
						let y = rv.length;
						let x = rowValues.length;
						var isChecked = this.checked;

						var checkboxes = listContainer.find('input[type="checkbox"]');

						//var customerId = checkboxes[i].parentNode.getAttribute('customerId');
						//var cus = $(this).parent().data('customerId');
						if (isChecked) {
							const rowValues = JSON.parse(sessionStorage.getItem("rowValues"));

							// Do something with the row values.
							for (let i = 0; i < rowValues.length; i++) {
								if (Array.isArray(rowValues) && rowValues.length > 0) {



									checkboxes[i + 1].checked = isChecked;

									const customerId = rowValues[i].Portid;

									selectedCustomerIds.push(customerId);

								}

							}


							var listContainervo = $('#listContainervouchar');
							var checkboxes1 = listContainervo.find('input[type="checkbox"]');

							for (var j = 0; j < checkboxes1.length; j++) {
								checkboxes1[j].checked = isChecked;
							}

							sessionStorage.setItem('sessionArray', JSON.stringify(selectedCustomerIds));
							selectedCustomerIds = [];
							FinalFunTaskDashBord();


						}
						else {
							var listContainervo = $('#listContainervouchar');
							var checkboxes1 = listContainervo.find('input[type="checkbox"]');

							for (var j = 0; j < checkboxes1.length; j++) {
								checkboxes1[j].checked = false;
							}

							for (var i = 0; i <= x; i++) {
								var empty = [0];
								sessionStorage.setItem('sessionArray', JSON.stringify(empty));
								checkboxes[i].checked = false;
							}

							var txtcustomer1 = (document.querySelector('input[name=txtcustomer]').value != '')
								? document.querySelector('input[name=txtcustomer]').value : '0';

							if (txtcustomer1 != "0") {
								txtcustomer.value = "";
							}

							var txtSalesPerson1 = (document.querySelector('input[name=txtSalesPerson]').value != '')
								? document.querySelector('input[name=txtSalesPerson]').value : '0';

							if (txtSalesPerson1 != "0") {
								txtSalesPerson.value = "";
							}

							selectedCustomerIds = [];
							FinalFunTaskDashBord();
						}


					});


					listContainer.prepend(selectAllCheckBoxbranch);
					$.each(dataList, function (index, item) {
						var listItem = $('<li>');



						var checkbox1 = $('<input>').attr('type', 'checkbox').attr('value', item.PortName).attr('checked', 'checked');



						checkbox1.change(function () {



							var isChecked = $(this).is(':checked');
							var vouchar = $(this).parent().data('Portid');
							selectAllCheckBoxbranch.checked = false;
							if (isChecked) {
								var checkboxes = listContainer.find('input[type="checkbox"]');

								const rowValuesvouchar = JSON.parse(sessionStorage.getItem("rowValues"));

								for (let i = 0; i < rowValuesvouchar.length; i++) {
									if (Array.isArray(rowValuesvouchar) && rowValuesvouchar.length > 0) {
										var checkboxess = listContainer.find('input[type="checkbox"]');
										var ch = checkboxess[i + 1].checked;

										if (ch == true) {
											const customerId = rowValuesvouchar[i].Portid;

											sessionArray.push(customerId)

										}

									}
								}
								var listContainervo = $('#listContainervouchar');
								var checkboxes1 = listContainervo.find('input[type="checkbox"]');

								for (var j = 0; j < checkboxes1.length; j++) {
									checkboxes1[j].checked = isChecked;
								}

								sessionStorage.setItem('sessionArray', JSON.stringify(sessionArray));
								sessionArray = [];
								FinalFunTaskDashBord();


								// Add customer ID to the array when checkbox is checked
							}
							else {

								var checkboxes = listContainer.find('input[type="checkbox"]');

								const rowValuesvouchar = JSON.parse(sessionStorage.getItem("rowValues"));

								for (let i = 0; i < rowValuesvouchar.length; i++) {
									if (Array.isArray(rowValuesvouchar) && rowValuesvouchar.length > 0) {
										var checkboxess = listContainer.find('input[type="checkbox"]');
										var ch = checkboxess[i + 1].checked;

										if (ch == true) {
											const customerId = rowValuesvouchar[i].Portid;


											sessionArray.push(customerId)

										}

									}
								}



								sessionStorage.setItem('sessionArray', JSON.stringify(sessionArray));
								sessionArray = [];
								FinalFunTaskDashBord();


							}



						});



						listItem.append(checkbox1);
						listItem.append(item.PortName);


						listItem.data('Portid', item.Portid);

						listContainer.append(listItem);



					});
				}
				else if (inputText != 1 & dataList.length == 0) {
					document.getElementById('sp').style.display = 'none';
					alert("No Data For The SalesPerson / Assigne");
				}
			},
			error: function (xhr, status, error) {
				console.error("AJAX error:", error);
			}
		});
	});

}
function callWebMethodbranchid(selectedItem) {
	// Call your web method here with the selected item




	$(document).ready(function () {
		$(function () {

			$.ajax({
				type: 'POST',
				dataType: 'json',
				contentType: 'application/json',
				url: '../TaskDetailsDashMain.aspx/GetBranchbasedCard',
				data: "{'bid':'" + selectedItem + "'}",
				success:
					function (response) {

						console.log(response.data);
						//const obj = JSON.parse(response);
						//const data = obj;
						//return data;
						dynamiccard(response.d);

					},

				error: function () {
					alert("Error loading data! Please try again.");
				}
			});
		})
	})
}

function callWebMethodvouchar(selectedItem) {
	// Call your web method here with the selected item




	$(document).ready(function () {
		$(function () {

			$.ajax({
				type: 'POST',
				dataType: 'json',
				contentType: 'application/json',
				url: '../TaskDetailsDashMain.aspx/GetVoubasedCard',
				data: "{'vou':'" + selectedItem + "'}",
				success:
					function (response) {

						console.log(response.data);
						//const obj = JSON.parse(response);
						//const data = obj;
						//return data;
						dynamiccard(response.d);

					},

				error: function () {
					alert("Error loading data! Please try again.");
				}
			});
		})
	})
}
function voulistChanged() {
	branchlistChanged();
	$(document).ready(function () {
		$.ajax({
			type: "POST",
			url: "TaskDetailsDashMain.aspx/GetVouDetails",
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function (response) {
				var dataList = response.d;
				sessionStorage.setItem("rowValuesvouchar", JSON.stringify(dataList));
				var listContainer = $('#listContainervouchar');
				listContainer.empty(); // Clear previous items


				if (dataList.length != 0) {
					/*var listItem1 = $('<li>');*/
					var selectedvouchaerIds = []; // Array to store selected customer IDs
					var selectedCustomerIdsuncheck = [];
					var sessionvouchar = [];
					var sessiongetvou = [];
					var sessionArrayvouchar = [];

					var selectAllCheckBoxvouchar = document.createElement('input');
					selectAllCheckBoxvouchar.setAttribute('type', 'checkbox');
					selectAllCheckBoxvouchar.setAttribute('checked', 'checked')
					selectAllCheckBoxvouchar.classList.add('select-all');
					selectAllCheckBoxvouchar.Text = "Select";
					//var label = document.createElement('label');
					//listItem1.appendChild(selectAllCheckbox);
					//listItem1.appendChild(document.createTextNode(' Select All'));
					//document.getElementById('<%= sp.ClientID %>').style.display = 'block';

					document.getElementById('vouchar').style.display = 'inherit';



					var isChecked = selectAllCheckBoxvouchar.checked;
					var checkboxes = listContainer.find('input[type="checkbox"]');





					if (isChecked) {
						const rowValuesvouchar = JSON.parse(sessionStorage.getItem("rowValuesvouchar"));

						// Do something with the row values.
						for (let i = 0; i < rowValuesvouchar.length; i++) {
							if (Array.isArray(rowValuesvouchar) && rowValuesvouchar.length > 0) {
								// Accessing Customerid property of the first object in rowValues array
								const vouId = rowValuesvouchar[i].Voucherid;

								sessiongetvou.push(vouId);

								selectedvouchaerIds.push(vouId);

								// Do something with customerId
								/*console.log("Customer ID:", customerId);*/
							}
						}


						sessionStorage.setItem('sessionArrayvouchar', JSON.stringify(sessiongetvou));
						selectedvouchaerIds = [];
						FinalFunTaskDashBord();


						//selectedvouchaerIds.push(customerId);
						//selectedvouchaerIds = [];

					}


					//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
					selectAllCheckBoxvouchar.addEventListener('change', function () {
						const rowValuesvouchar = JSON.parse(sessionStorage.getItem("rowValuesvouchar"));
						let x = rowValuesvouchar.length;
						var isChecked = this.checked;
						var checkboxes = listContainer.find('input[type="checkbox"]');


						//var customerId = checkboxes[i].parentNode.getAttribute('customerId');
						var cus = $(this).parent().data('customerId');
						if (isChecked) {

							const rowValuesvouchar = JSON.parse(sessionStorage.getItem("rowValuesvouchar"));

							// Do something with the row values.
							for (let i = 0; i < rowValuesvouchar.length; i++) {
								if (Array.isArray(rowValuesvouchar) && rowValuesvouchar.length > 0) {
									// Accessing Customerid property of the first object in rowValues array
									var checkboxess = listContainer.find('input[type="checkbox"]');


									const customerId = rowValuesvouchar[i].Voucherid;
									checkboxes[i + 1].checked = isChecked;

									var ch = checkboxess[i + 1].checked;
									selectedvouchaerIds.push(customerId);

									// Do something with customerId
									/*console.log("Customer ID:", customerId);*/
								}
							}
							sessionStorage.setItem('sessionArrayvouchar', JSON.stringify(selectedvouchaerIds));
							selectedvouchaerIds = [];
							FinalFunTaskDashBord();

							//selectedvouchaerIds.push(customerId);
						}
						else {
							for (var i = 0; i <= x; i++) {
								var empty = [0];

								sessionStorage.setItem('sessionArrayvouchar', JSON.stringify(empty));
								checkboxes[i].checked = false;
							}
							selectedvouchaerIds = [];
							FinalFunTaskDashBord();
						}

						//sessionStorage.setItem('sessionArray1', JSON.stringify(selectedvouchaerIds));
						//callWebMethod(selectedvouchaerIds);
						//selectedvouchaerIds = [];
					});
					//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
					//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

					//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

					listContainer.prepend(selectAllCheckBoxvouchar);
					$.each(dataList, function (index, item) {
						var listItem = $('<li>');









						var checkbox1 = $('<input>').attr('type', 'checkbox').attr('value', item.Voucharname).attr('checked', 'checked');



						checkbox1.change(function () {


							var isChecked = $(this).is(':checked');
							var vouchar = $(this).parent().data('Voucherid');
							selectAllCheckBoxvouchar.checked = false;

							//selectedvouchaerIds.push(customerId);
							//callWebMethodbranchid(selectedvouchaerIds);
							if (isChecked) {


								var checkboxes = listContainer.find('input[type="checkbox"]');




								const rowValuesvouchar = JSON.parse(sessionStorage.getItem("rowValuesvouchar"));

								// Do something with the row values.
								for (let i = 0; i < rowValuesvouchar.length; i++) {
									if (Array.isArray(rowValuesvouchar) && rowValuesvouchar.length > 0) {
										// Accessing Customerid property of the first object in rowValues array
										var checkboxess = listContainer.find('input[type="checkbox"]');
										var ch = checkboxess[i + 1].checked;

										if (ch == true) {
											const customerId = rowValuesvouchar[i].Voucherid;


											sessionvouchar.push(customerId)

										}


										// Do something with customerId
										/*console.log("Customer ID:", customerId);*/
									}
								}






								sessionStorage.setItem('sessionArrayvouchar', JSON.stringify(sessionvouchar));
								sessionvouchar = [];
								FinalFunTaskDashBord();


								// Add customer ID to the array when checkbox is checked
							}
							else {

								var checkboxes = listContainer.find('input[type="checkbox"]');




								const rowValuesvouchar = JSON.parse(sessionStorage.getItem("rowValuesvouchar"));

								// Do something with the row values.
								for (let i = 0; i < rowValuesvouchar.length; i++) {
									if (Array.isArray(rowValuesvouchar) && rowValuesvouchar.length > 0) {
										// Accessing Customerid property of the first object in rowValues array
										var checkboxess = listContainer.find('input[type="checkbox"]');
										var ch = checkboxess[i + 1].checked;

										if (ch == true) {
											const customerId = rowValuesvouchar[i].Voucherid;


											sessionvouchar.push(customerId)

										}


										// Do something with customerId
										/*console.log("Customer ID:", customerId);*/
									}
								}






								sessionStorage.setItem('sessionArrayvouchar', JSON.stringify(sessionvouchar));
								sessionvouchar = [];
								FinalFunTaskDashBord();

							}


						});


						//var checkbox = $('<input>').attr('type', 'checkbox').attr('value', item.PortName).on('change', function () {
						//	if ($(this).is(':checked')) {
						//		var productId = $(this).parent().data('productId'); // Access productId from data attribute
						//		// Call web method when checkbox is checked, passing productId
						//		callWebMethod(productId);
						//	}
						//});
						listItem.append(checkbox1);
						listItem.append(item.Voucharname); // Display product name instead of product ID

						// Attach productId as a data attribute to the list item
						listItem.data('Voucherid', item.Voucherid);

						listContainer.append(listItem);



					});
				}
				else if (inputText != 1 & dataList.length == 0) {
					document.getElementById('sp').style.display = 'none';
					alert("No Data For The SalesPerson / Assigne");
				}
			},
			error: function (xhr, status, error) {
				console.error("AJAX error:", error);
			}
		});
	});

}



function FinalFunTaskDashBord() {
	// Call your web method here with the selected item


	var branchid = JSON.parse(sessionStorage.getItem("sessionArray"));
	if (branchid == null || branchid == "") {
		branchid = "0";

	}
	if (branchid == "0") {
		var listContainervo = $('#listContainervouchar');
		var checkboxes1 = listContainervo.find('input[type="checkbox"]');

		for (var j = 0; j < checkboxes1.length; j++) {
			checkboxes1[j].checked = false;
		}


		var txtcustomer1 = (document.querySelector('input[name=txtcustomer]').value != '')
			? document.querySelector('input[name=txtcustomer]').value : '0';

		if (txtcustomer1 != "0") {
			txtcustomer.value = "";
		}

		var txtSalesPerson1 = (document.querySelector('input[name=txtSalesPerson]').value != '')
			? document.querySelector('input[name=txtSalesPerson]').value : '0';

		if (txtSalesPerson1 != "0") {
			txtSalesPerson.value = "";
		}


		alert("Plese Select The Branch");
	}
	var voutype = JSON.parse(sessionStorage.getItem("sessionArrayvouchar"));
	if (voutype == null || voutype == "0" || voutype == " ") {
		voutype = "0";
	}





	//var branch = ddl_branch.options[ddl_branch.selectedIndex];

	//// Get the value of the selected option
	//var branchvalue = branch.value;







	var txtSalesPerson1 = (document.querySelector('input[name=txtSalesPerson]').value != '')
		? document.querySelector('input[name=txtSalesPerson]').value : '0';

	var txtSalesPerson = '0';

	if (txtSalesPerson1 != '0') {
		txtSalesPerson = (document.querySelector('input[name=hdf_salesperson]').value != '')
			? document.querySelector('input[name=hdf_salesperson]').value : '0';

		sessionStorage.setItem('sessionsalesperson', JSON.stringify(txtSalesPerson));


	}

	var txtcustomer1 = (document.querySelector('input[name=txtcustomer]').value != '')
		? document.querySelector('input[name=txtcustomer]').value : '0';

	var txtcustomer = '0';

	if (txtcustomer1 != '0') {

		txtcustomer = (document.querySelector('input[name=hf_customerid]').value != '')
			? document.querySelector('input[name=hf_customerid]').value : '0';

		sessionStorage.setItem('sessioncustomer', JSON.stringify(txtcustomer));

	}




	$(document).ready(function () {
		$(function () {

			$.ajax({
				type: 'POST',
				dataType: 'json',
				contentType: 'application/json',
				url: '../TaskDetailsDashMain.aspx/GetTaskbasedCard4all',
				data: "{'bid':'" + branchid + "','voutype':'" + voutype + "','customerid':'" + txtcustomer + "','empid':'" + txtSalesPerson + "'}",
				success:
					function (response) {

						console.log(response.data);
						//const obj = JSON.parse(response);
						//const data = obj;
						//return data;
						dynamiccard(response.d);

					},

				error: function () {
					alert("Error loading data! Please try again.");
				}
			});
		})
	})
}
//dynamiccard()
//GetEmpolyeeJson()
