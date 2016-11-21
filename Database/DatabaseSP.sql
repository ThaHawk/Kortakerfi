DELIMITER $$

-- Insert Member
DROP PROCEDURE IF EXISTS InsertMember $$

CREATE PROCEDURE InsertMember(m_id VARCHAR(20), m_name VARCHAR(100), m_phone VARCHAR(20), m_email VARCHAR(100), membership_Type VARCHAR(100), due_Date DATE, passes_Remaining INT(11))
BEGIN
	INSERT INTO Personal(SocialSecurityID, Name, Phone, Email) VALUES (m_id, m_name, m_phone, m_email);
	INSERT INTO Membership(SocialSecurityID, MembershipType, PassesRemaining, DueDate, LastPaidDate, SignUpDate) VALUES (m_id, membership_Type, passes_Remaining, due_Date, CURDATE(), CURDATE());
END $$

-- Update Member
DROP PROCEDURE IF EXISTS UpdateMember $$

CREATE PROCEDURE UpdateMember(m_id VARCHAR(20), m_name VARCHAR(100), m_phone VARCHAR(20), m_email VARCHAR(100), membership_Type VARCHAR(100), due_Date DATE, passes_Remaining INT(11))
BEGIN
	UPDATE Personal SET Name = m_name, Phone = m_phone, Email = m_email WHERE SocialSecurityID = m_id;
	UPDATE Membership SET MembershipType = membership_Type, PassesRemaining = passes_Remaining, DueDate = due_Date WHERE SocialSecurityID = m_id;
END $$

-- Get List Of Members For Search From ID
DROP PROCEDURE IF EXISTS MemberSearchListFromID $$

CREATE PROCEDURE MemberSearchListFromID(m_id VARCHAR(20))
BEGIN
	SELECT Membership.MembershipID, Personal.Name
	FROM Personal
	INNER JOIN Membership ON (Membership.SocialSecurityID = Personal.SocialSecurityID)
	WHERE Membership.MembershipID = m_id;
END $$

-- Get List Of Members For Search From Name
DROP PROCEDURE IF EXISTS MemberSearchListFromName $$

CREATE PROCEDURE MemberSearchListFromName(m_name VARCHAR(100))
BEGIN
	SELECT Membership.MembershipID, Personal.Name
	FROM Personal
	INNER JOIN Membership ON (Membership.SocialSecurityID = Personal.SocialSecurityID)
	WHERE Personal.Name = m_name;
END $$

-- Get All Member Info
DROP PROCEDURE IF EXISTS GetMemberInfo $$

CREATE PROCEDURE GetMemberInfo(m_id VARCHAR(20))
BEGIN
	SELECT Personal.SocialSecurityID, Personal.Name, Personal.Phone, Personal.Email, Personal.Comment, Membership.MembershipType, Membership.PassesRemaining, Membership.DueDate, Membership.LastPaidDate, Membership.SignUpDate
	FROM Personal
	INNER JOIN Membership ON (Membership.SocialSecurityID = Personal.SocialSecurityID)
	WHERE Membership.MembershipID = m_id;
END $$

-- Add Comment
DROP PROCEDURE IF EXISTS AddComment $$

CREATE PROCEDURE AddComment(p_id VARCHAR(20), p_comment VARCHAR(255))
BEGIN
	UPDATE Personal SET Comment = p_comment WHERE SocialSecurityID = p_id;
END $$

-- Record a Visit
DROP PROCEDURE IF EXISTS RecordVisit $$

CREATE PROCEDURE RecordVisit(m_id VARCHAR(20), isPunchcard int(1))
BEGIN
	UPDATE Membership SET PassesRemaining = PassesRemaining - isPunchcard WHERE MembershipID = m_id;

	INSERT INTO Visits(MembershipID, CheckInDate) VALUES (m_id, NOW());
END $$

-- Get Visits
DROP PROCEDURE IF EXISTS GetVisits $$

CREATE PROCEDURE GetVisits(m_id VARCHAR(20))
BEGIN
	SELECT MembershipID, CheckInDate FROM Visits WHERE MembershipID = m_id
	ORDER BY CheckInDate DESC;
END $$

DELIMITER ;