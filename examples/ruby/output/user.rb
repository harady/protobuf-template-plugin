# This file is auto-generated. Do not edit manually.

module UserRole
  USER_ROLE_UNSPECIFIED = 0
  USER_ROLE_GUEST = 1
  USER_ROLE_MEMBER = 2
  USER_ROLE_ADMIN = 3
end

class User
  attr_accessor :id, :name, :email, :role, :tags

  def initialize(id: nil, name: nil, email: nil, role: nil, tags: [])
    @id = id
    @name = name
    @email = email
    @role = role
    @tags = tags
  end
end

class GetUserRequest
  attr_accessor :id

  def initialize(id: nil)
    @id = id
  end
end

class GetUserResponse
  attr_accessor :user

  def initialize(user: nil)
    @user = user
  end
end
