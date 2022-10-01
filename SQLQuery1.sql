select u.id, u.email, r.name
from AspNetUsers u join AspNetUserRoles ur on u.id = ur.UserId join AspNetRoles r on r.id = ur.RoleId;
