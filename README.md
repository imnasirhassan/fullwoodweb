Solution:
1. src - Projects for running application
2. tests - Just a few tests for service and repository projects to show unit tests


Application Steps:
1. Kindly download the repo from https://github.com/imnasirhassan/fullwoodweb
2. Restore packages and build solution
3. Make fullwoodweb as startup project
4. Run application
5. Cow listing page should be accessible without any login
6. All actions (CRUD) under Cow should be protected with Admin or User login
7. Click Create link to create new Cow
8. Login page will be displayed with 2 options Admin and User
9. Login as Admin or User to perform all CRUD operations however, only Admin can import Json data from file 
10. For import Cow data from Json  - click on Import link
11. If you are logged in as User -> Access Denied will be displayed 
12. Clear Application cookie to reset authentication
13. login as Admin and import data


Change of user role;
1. Application uses cookie based authentication, if you are already logged in, kindly open dev tools and clear cookies
2. Goto /account/login
3. Select Admin or User login
4. After login, user should be redirected to list screen


Limited Consideration:
1. Authentication and Authorization - just to demo application security restrictions
2. Fewer tests just to demo the testing functionality
3. Cow functionality implementation and Milking functionality can be added at later stage


Improvements;
1. Input validations and restrictions
2. Authentication and Authorization implementation
3. Exception and Error handling
4. Application uses search/ filter and pagination functionality from javascript library which can be handled thought code if needed for large dataset
5. More tests for better code coverage and quality confidence
6. File is copied currently to /files folder without analyzing security risk. Later, it can be copied to restricted location with restrcited user permissions to avoid running executable from directory
7. File extension validation before upload/ copy
8. File content validation with exception/ error handling
9. Etc
