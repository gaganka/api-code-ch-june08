# api-code-ch-june08* 
I have tried to handle null value scenarios. But might have missed few.
* There can be many business validations. But i have checked for just couple 
(like report can't be modified if 'mailed' flag is true)

1. The services need to be called with ApiKey YWRtaW46QWRtaW5AMjAyMQ
2. Tested the patient api with below json

--Test patient json
{
"id":20010,
"patientCode":"IN/004/200021",
"firstName":"ethan",
"middleName":"s",
"lastName":"hunt",
"dob":"08/08/84",
"gender":"male",
"phone":"(615) 344-1000",
"addressLine1":"add1 N",
"addressLine2":"add2 St",
"city": "Nashville",
"zip": "37211",
"state": "TN"
}

3. Tested the lab report api with below data
--Lab report
{
  "id":1,
  "patientId":20010,
  "reportDate":"06/04/2021",
  "testType":"BloodCount",
  "testTime":"06/03/2021 08:00:00 AM",
  "enteredTime":"06/03/2021 10:00:00 AM",
  "physicianName":"Physician One",
  "verifiedBy":"v name",
  "result":"Result text",
  "isMailed":false
}

{
  "id":2,
  "patientId":20010,
  "reportDate":"06/04/2021",
  "testType":"LipidPanel",
  "testTime":"06/03/2021 08:30:00 AM",
  "enteredTime":"06/03/2021 10:30:00 AM",
  "physicianName":"Physician One",
  "verifiedBy":"v name",
  "result":"Result text",
  "isMailed":false
}


Creted Basic simple search. 
(for now it is using and criteria to match patinet id and test time (only))

{
  "patientID": 20010,
  "testType": "BloodCount",
  "fromDate": "06/02/2021 08:00:00 AM",
  "toDate": "06/04/2021 08:00:00 AM"
}

{
  "patientID": 20010,
  "testType": "LipidPanel",
  "fromDate": "06/02/2021 08:00:00 AM",
  "toDate": "06/04/2021 08:00:00 AM"
}
