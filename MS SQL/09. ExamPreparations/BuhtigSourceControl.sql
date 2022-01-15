-- 01. Потребители
SELECT id, `username` FROM users
ORDER BY id;

-- 02. Късметлийски числа
SELECT * FROM repositories_contributors
WHERE repository_id = contributor_id
ORDER BY repository_id;

-- 03. Проблеми и потребители
SELECT i.id, CONCAT(u.username, " : ", i.title) AS issue_assignee 
FROM issues AS i
JOIN users AS u ON u.id = i.assignee_id
ORDER BY i.id DESC;

-- 04. Файлове без директории
SELECT id, name, CONCAT(size, "KB") AS size FROM files
WHERE id NOT IN 
(
	SELECT DISTINCT parent_id 
	FROM files 
	WHERE parent_id IS NOT NULL
)
ORDER BY id;

-- 05. Активни хранилища
SELECT r.id, r.name, COUNT(i.repository_id) AS issues FROM repositories AS r
JOIN issues AS i ON i.repository_id = r.id
GROUP BY r.id, r.name 
ORDER BY issues DESC, r.id
LIMIT 5;

-- 06. Хранилището с най-много участници
SELECT r.id, r.name, (
	SELECT COUNT(c.id) 
    FROM commits AS c 
    WHERE c.repository_id = r.id GROUP BY r.id
) as commits, COUNT(rc.contributor_id) AS contributors 
FROM repositories AS r
JOIN repositories_contributors AS rc ON rc.repository_id = r.id
GROUP BY r.id
ORDER BY contributors DESC, r.id
LIMIT 1;

-- 07. Хранилища и потребители
SELECT r.id, r.name, COUNT(c.contributor_id) AS users 
FROM repositories AS r
LEFT JOIN commits AS c ON c.repository_id = r.id
GROUP BY r.id
ORDER BY users DESC, r.id






