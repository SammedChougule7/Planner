# Planner
# TODO
## Database Structure
### User Table
1. userId- int
2. email- varchar()
3. firstName- varchar()
4. lastName- varchar()

### Task Table
1. id- int
2. userId- foreign key
3. title- varchar()
4. desc- varchar()
5. dueDate- date
6. startDate- date
7. createdDate- date
8. modifiedDate- date
9. progress- varchar()

