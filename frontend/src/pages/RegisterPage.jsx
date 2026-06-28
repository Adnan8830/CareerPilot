import { useState } from "react";
import { register } from "../api/authApi";
import { Link, useNavigate } from "react-router-dom";
import "./Auth.css";

function RegisterPage() {
  const [formData, setFormData] = useState({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
    yearOfExperience: "",
    linkedInUrl: "",
    githubUrl: "",
  });

  const navigate = useNavigate();

  const handleChange = (event) => {
    const { name, value } = event.target;

    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      const registerRequest = {
        firstName: formData.firstName,
        lastName: formData.lastName,
        email: formData.email,
        password: formData.password,
      };

      await register(registerRequest);

      alert("Registration successful!");
      navigate("/");
    } catch (error) {
      console.error(error);
      alert("Registration failed. Please try again.");
    }
  };

  return (
    <div className="auth-container">
      <div className="auth-card">

        <h1>CareerPilot</h1>
        <h2>Create Account</h2>

        <form onSubmit={handleSubmit}>

          <div className="form-group">
            <label>First Name</label>
            <input
              type="text"
              name="firstName"
              value={formData.firstName}
              onChange={handleChange}
              placeholder="Enter first name"
            />
          </div>

          <div className="form-group">
            <label>Last Name</label>
            <input
              type="text"
              name="lastName"
              value={formData.lastName}
              onChange={handleChange}
              placeholder="Enter last name"
            />
          </div>

          <div className="form-group">
            <label>Email</label>
            <input
              type="email"
              name="email"
              value={formData.email}
              onChange={handleChange}
              placeholder="Enter email"
            />
          </div>

          <div className="form-group">
            <label>Password</label>
            <input
              type="password"
              name="password"
              value={formData.password}
              onChange={handleChange}
              placeholder="Enter password"
            />
          </div>

          {/* Keep these fields for future backend implementation */}

          <div className="form-group">
            <label>Years of Experience</label>
            <input
              type="number"
              name="yearOfExperience"
              value={formData.yearOfExperience}
              onChange={handleChange}
              placeholder="e.g. 3"
            />
          </div>

          <div className="form-group">
            <label>LinkedIn URL</label>
            <input
              type="text"
              name="linkedInUrl"
              value={formData.linkedInUrl}
              onChange={handleChange}
              placeholder="https://linkedin.com/in/..."
            />
          </div>

          <div className="form-group">
            <label>GitHub URL</label>
            <input
              type="text"
              name="githubUrl"
              value={formData.githubUrl}
              onChange={handleChange}
              placeholder="https://github.com/..."
            />
          </div>

          <button className="btn-primary" type="submit">
            Register
          </button>

        </form>

        <p className="auth-footer">
          Already have an account?{" "}
          <Link to="/">Login</Link>
        </p>

      </div>
    </div>
  );
}

export default RegisterPage;