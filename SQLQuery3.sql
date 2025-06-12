
-- Insert Users
INSERT INTO Users (Name, Email, PasswordHash) VALUES
('John Doe', 'john.doe@example.com', 'hashedpassword1'),
('Jane Smith', 'jane.smith@example.com', 'hashedpassword2'),
('Mike Johnson', 'mike.johnson@example.com', 'hashedpassword3'),
('Sarah Williams', 'sarah.williams@example.com', 'hashedpassword4'),
('David Brown', 'david.brown@example.com', 'hashedpassword5');

-- Insert Projects
INSERT INTO Projects ( Name, Description, StartDate, EndDate, OwnerId) VALUES
('E-Commerce Platform', 'Build a modern e-commerce solution', '2023-01-01', '2023-06-30', 1),
('Mobile Banking App', 'Develop a secure mobile banking application', '2023-02-15', '2023-08-15', 2),
('Inventory Management', 'System to track warehouse inventory', '2023-03-01', '2023-09-30', 3);

-- Insert Project Members
INSERT INTO ProjectMembers ( ProjectId, UserId, Role) VALUES
(1, 1, 'Project Manager'),
(1, 2, 'Lead Developer'),
(1, 3, 'QA Engineer'),
(2, 2, 'Project Manager'),
(2, 4, 'Developer'),
(2, 5, 'UI/UX Designer'),
(3, 3, 'Project Manager'),
(3, 1, 'Backend Developer'),
(3, 5, 'Frontend Developer');

-- Insert Sprints
INSERT INTO Sprints (Name, StartDate, EndDate, ProjectId) VALUES
('Sprint 1 - Foundation', '2023-01-01', '2023-01-14', 1),
('Sprint 2 - Core Features', '2023-01-15', '2023-01-28', 1),
('Sprint 1 - Prototype', '2023-02-15', '2023-03-01', 2),
('Sprint 1 - Setup', '2023-03-01', '2023-03-14', 3),
('Sprint 2 - Database', '2023-03-15', '2023-03-28', 3);

-- Insert Epics
INSERT INTO Epics (Title, Description, ProjectId) VALUES
('User Authentication', 'Implement secure user authentication system', 1),
('Product Catalog', 'Display and manage products in the store', 1),
('Account Management', 'Bank account operations for users', 2),
('Inventory Tracking', 'Track items in the warehouse', 3),
('Reporting', 'Generate reports for all modules', 3);

-- Insert Stories
INSERT INTO Stories (Title, Description, EpicId) VALUES
('User Registration', 'Allow new users to create accounts', 1),
('Login/Logout', 'Implement login and logout functionality', 1),
('Product List Page', 'Display all products with pagination', 2),
('Product Details', 'Show detailed information for a product', 2),
('Balance Check', 'Allow users to check account balance', 3),
('Item Search', 'Search for items in inventory', 4),
('Stock Alerts', 'Notify when stock is low', 4),
('Sales Report', 'Generate monthly sales report', 5);

-- Insert Acceptance Criteria
INSERT INTO AcceptanceCriterias ( Description, StoryId, IsMet) VALUES
('User can fill registration form with valid data', 1, 1),
('System sends confirmation email after registration', 1, 0),
('User can login with correct credentials', 2, 1),
('System prevents login with wrong credentials', 2, 1),
('Products are displayed in a grid layout', 3, 1),
('Pagination works with 10 items per page', 3, 0),
('Product details include image, price, description', 4, 1),
('Balance is displayed within 2 seconds of request', 5, 1);

-- Insert Task Items
INSERT INTO Tasks (Title, Description, StoryId, IsCompleted, AssignedUserId) VALUES
('Design registration form', 'Create UI for user registration', 1, 1, 2),
('Implement backend validation', 'Validate user input on server', 1, 1, 1),
('Create login page', 'Design login page UI', 2, 1, 2),
('Implement auth service', 'Backend authentication logic', 2, 1, 1),
('Product card component', 'Create reusable product card', 3, 1, 5),
('Pagination component', 'Implement pagination controls', 3, 0, 5),
('Product detail API', 'Create API endpoint for product details', 4, 1, 1),
('Balance query service', 'Implement service to fetch balance', 5, 1, 4),
('Search index setup', 'Configure Elasticsearch for inventory', 6, 0, 3),
( 'Alert threshold config', 'Allow admin to set stock thresholds', 7, 0, 3);

-- Insert Sprint Tasks
INSERT INTO SprintTasks ( SprintId, TaskItemId) VALUES
(1, 1),
(1, 2),
(1, 3),
(2, 4),
(2, 5),
(2, 6),
(3, 7),
(3, 8),
(4, 9),
( 5, 10);

-- Insert Comments
INSERT INTO Comments ( Content, TaskItemId, UserId, CreatedAt) VALUES
('Should we add social login options?', 1, 1, '2023-01-02 10:15:00'),
('Yes, good idea. Will create a follow-up task.', 1, 2, '2023-01-02 11:30:00'),
('Validation rules need to be updated per new requirements', 2, 3, '2023-01-03 09:45:00'),
('I think we should use JWT for authentication', 4, 1, '2023-01-16 14:20:00'),
('Agreed, JWT is the way to go', 4, 2, '2023-01-16 15:05:00');

-- Insert Attachments
INSERT INTO Attachments (FileName, FilePath, TaskItemId, UploadedAt) VALUES
('registration_wireframe.png', '/attachments/1/wireframe.png', 1, '2023-01-01 13:45:00'),
('auth_sequence.pdf', '/attachments/4/sequence.pdf', 4, '2023-01-15 16:30:00'),
('product_card_design.sketch', '/attachments/5/design.sketch', 5, '2023-01-20 11:15:00');

-- Insert Activity Logs
INSERT INTO ActivityLogs (TaskItemId, UserId, Action, Timestamp) VALUES
(1, 2, 'Task created', '2023-01-01 09:00:00'),
(1, 2, 'Started work', '2023-01-01 10:30:00'),
(1, 2, 'Marked as completed', '2023-01-03 14:00:00'),
(2, 1, 'Task created', '2023-01-01 09:05:00'),
(2, 1, 'Started work', '2023-01-02 08:45:00'),
(4, 1, 'Implemented core auth logic', '2023-01-16 12:30:00');