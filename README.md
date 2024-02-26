# Recruit system
[TOC]
## Background of the project
This is a simple and efficient recruitment system. Its core functionality allows job seekers to browse various positions online and submit their CVs to positions of interest via email. Recruiters can easily post and manage job information in the backend, as well as view job applications for positions.

## Project Members

- Yu Huang(Mobile Application)
- Yuqi Wang(Back End)
- Chen Zhang(Front End)
- Yonggang Li(Product)

## Quick start

# Ideas and implementation

## Architecture

## Storage design
Based on the above architectural principles and requirements, the storage only relies on Myqsl as RDB.

### Table Structure
- employer_info Table  <br/>
``` sql
CREATE TABLE `employer_info` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `created_time` timestamp NOT NULL COMMENT 'created time',
  `updated_time` timestamp NOT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT 'updated time',
  `company_name` varchar(255) NOT NULL COMMENT 'company_name',
  `official_web` varchar(255) NOT NULL DEFAULT '' COMMENT 'official website',
  `email` varchar(255) NOT NULL DEFAULT '' COMMENT 'email',
  `employee_num` int(10) unsigned zerofill NOT NULL COMMENT 'employee num',
  PRIMARY KEY (`id`),
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb3;
```
- position_info <br/>
``` sql
CREATE TABLE `position_info` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `published_employer_id` int(10) unsigned zerofill NOT NULL COMMENT 'employer id',
  `planed_hired_num` int(10) unsigned zerofill NOT NULL COMMENT 'hired num',
  `applied_num` int(10) unsigned zerofill NOT NULL COMMENT 'applied num',
  `status` int(10) unsigned zerofill NOT NULL COMMENT 'position status, 1: open, 2: close',
  `position_name` varchar(255) NOT NULL,
  `salary_range` varchar(255) NOT NULL,
  `postion_desc` text(2000),
  `start_time` timestamp NOT NULL COMMENT 'position start at',
  `end_time` timestamp NOT NULL COMMENT 'position end at',
  `created_time` timestamp NOT NULL,
  `updated_time` timestamp NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb3;
```
- applied_info <br/>
``` sql
CREATE TABLE `applied_info` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `candidate_email` varchar(255) NOT NULL COMMENT 'candidate email',
  `position_id` int(10) unsigned zerofill NOT NULL COMMENT 'position id',
  `applied_times` int(10) unsigned zerofill NOT NULL COMMENT 'applied times for same candidate',
  `status` int(10) unsigned zerofill NOT NULL COMMENT 'applying status, 1: pass; 2: reject',
  `created_time` timestamp NOT NULL,
  `updated_time` timestamp NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb3;
```

## API Protocol
The interface provides services through the HTTP protocol <br/>

- Publish Position
    - Desc <br/>
        For employer publish new positions.
    - Path:
        /api/publish_position
    - Content-type:
         application/x-www-form-urlencoded
    - Method:
        POST
    - Host:
    https://xxx.com
    - Params

    | name | type | required | Desc |Sample
    | :----:| :----: | :----: | :----: | :----:
    | position_name | string | true | position name for Showing|Senior Front-End engineer|
    | planed_hired_num | int | true | the maximum num of hired people|20|
    | desc | string | true | Job desc for this positoin| <div>This is a xxx</div>|
    | employer_id | int | true | employer ID| 2|
    | start_time | string | false | position start at, if empty means permenet position| YYY-MM-DD HH:ii:ss|
    | end_stime | string | false | position end at, if empty means permenet position| 2| YYY-MM-DD HH:ii:ss|

    - Response
    ``` json
    {
        "error_no": 0,
        "error_message": "success ",
        "data": {}
    }

    ```
- Update Position Info
    - Desc <br/>
        For updating position info by ID.
    - Path:
        /api/update_position
    - Content-type:
         application/x-www-form-urlencoded
    - Method:
        POST
    - Host:
    https://xxx.com
    - Params

    | name | type | required | Desc |Sample
    | :----:| :----: | :----: | :----: | :----:
    | position_id | int | true | position id|
    | planed_hired_num | int | true | the maximum num of hired people| 20 |
    | desc | string | true | Job desc for this positoin| <div>This is a xxx</div>|
    | employer_id | int | true | employer ID|12|
    | position_name | string | true | position name for Showing|Senior Front-End engineer|
    | status | int | true | position status 1 for close, 2 for open| 2|
    | start_time | string | false | position start at, if empty means permenet position| YYY-MM-DD HH:ii:ss|
    | end_stime | string | false | position end at, if empty means permenet position| 2| YYY-MM-DD HH:ii:ss|
    - Response
    ``` json
    {
        "error_no": 0,
        "error_message": "success ",
        "data": {}
    }

    ```
- Get position list
    - Desc <br/>
        For getting position list. order by updated date
    - Path:
        /api/getpositionlist
    - Method:
        GET
    - Host:
    https://xxx.com
    - Params

    | name | type | required | Desc |Sample
    | :----:| :----: | :----: | :----: | :----:
    | employer_id | int | false | employer id, if empty will recall all position |2|
    | page_size | int | false | page size, default 5 each paging |10|
    | page_num | int | false | page num, default 1  |2|
    - Response
    ``` json
    {
        "error_no": 0,
        "error_message": "success ",
        "data": {
          "list": [
                {
                    "position_id": 1,
                    "employer_id": 2,
                    "desc": "<div>Job Desc </div>",
                    "employer_name": "Google",
                    "start_time": "02/02/2024",
                    "end_time": "02/03/2024",
                    "updated_time": "15/02/2024",
                },
                {
                    "position_id": 2,
                    "employer_id": 2,
                    "desc": "<div>Job Desc </div>",
                    "employer_name": "Google",
                    "start_time": "02/02/2024",
                    "end_time": "02/03/2024",
                    "updated_time": "15/02/2024",
                }
            ],
        "has_more": true // still have next page or not.

          }
    }

    ```

- Apply for specific position
- Desc <br/>
     For applying specific position
    - Path:
        /api/apply
    - Method:
        POST
    - Host:
    https://xxx.com
    - Params

    | name | type | required | Desc |Sample
    | :----:| :----: | :----: | :----: | :----:
    | candidate_email | string | true | candidate email |xxx@gmail.com|
    | position_id | int | true | position ID |10|
    - Response
    ``` json
    {
    "error_no": 0,
    "error_message": "success ",
    "data": {}
    }
    ```
- Get applied info list
- Desc <br/>
     For getting applied info list
    - Path:
        /api/get_applied_info_list
    - Method:
        GET
    - Host:
    https://xxx.com
    - Params

    | name | type | required | Desc |Sample
    | :----:| :----: | :----: | :----: | :----:
    | employer_id | int | true | employer id |11|
    | position_id | int | true | position ID |10|
    - Response
    ``` json
    {
    "error_no": 0,
    "error_message": "success ",
    "data": {
            "list": [{
                    "applied_id": 25,
                    "candidate_email": "xxx@gmail.com",
                    "applied_times": 3,
                    "status": 1, // 1-pass, 2-reject, 0-CV wait to be reviewed  
                    "created_time": "02/02/2024",
                    "updated_time": "15/02/2024",
                    "has_mailed": true,
                },{
                    "applied_id": 34,
                    "candidate_email": "xxx@gmail.com",
                    "applied_times": 1,
                    "status": 1,
                    "created_time": "02/02/2024",
                    "updated_time": "15/02/2024",
                    "has_mailed": true,
                }],
            "has_more": true

          }
    }
    ```

- Edit applied info
    - Desc <br/>
        For Editting applied info
    - Path:
        /api/edit_applied_info
    - Method:
        GET
    - Host:
    https://xxx.com
    - Params

    | name | type | required | Desc |Sample
    | :----:| :----: | :----: | :----: | :----:
    | applied_id | int | true | applied info ID |11|
    | status | int | true | 1-pass, 2-reject|10|
    | has_mailed | bool | true | Have sent result to candidate via email, 1-has, 2-not|1|

    - Response

    ``` json
    {
    "error_no": 0,
    "error_message": "success ",
    "data": {}
    }
    ```