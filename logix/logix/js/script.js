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
				url: '../Home/OEOpsAndDocs.aspx/GetEmpolyeeJson',
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
					alertify.alert("Error loading data! Please try again.");
				}
			});
		})
	})
}

async function dynamiccard(data) {





	let parent = document.querySelector('.dynamic');

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
function handleSpanClick(value, taskName, Taskid) {
	// Your logic for handling span click, you can access the clicked value through the 'value' parameter
	//window.open('../CRM/Customersupport4All.aspx?type=Event%20Details&uiid=10052');
	var queryString = 'taskid=' + value; // Construct query string parameter

	var TaskValue = 'taskvalue=' + taskName + '&taskid=' + value;


	if (value == "12" || value == "13" || value == "27" || value == "26" || value == "14" || value == "16" || value == "1" || value == "6" || value == "24" || value == "25" || value == "28" || value == "29") {
		window.location.href = '../HOME/OEOpsAndDocs.aspx?' + queryString; // Navigate to ASPX page with query string
		//window.location.replace('../CRM/Customersupport4All.aspx?type=Event%20Details&uiid=10052' );
	}
	//else if (value == "PoD - ICD Movement") {
	//	window.location.href = '../ShipmentDetails/Transfer%20From%20ICD.aspx?' + queryString; // Navigate to ASPX page with query string
	//	//window.location.replace('../CRM/Customersupport4All.aspx?type=Event%20Details&uiid=10052' );
	//}

	else {
		window.location.href = '../CRM/Customersupport4AllTask.aspx?' + TaskValue; // Navigate to ASPX page with query string
		//window.location.replace('../CRM/Customersupport4All.aspx?type=Event%20Details&uiid=10052' );
	}

}

//dynamiccard()
//GetEmpolyeeJson()
