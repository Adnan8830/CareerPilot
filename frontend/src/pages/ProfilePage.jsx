import { useEffect, useState } from "react";
import { getProfile, updateProfile } from "../api/profileApi";
import "./Profile.css";

function ProfilePage() {
  const [profile, setProfile] = useState(null);
  const [formData, setFormData] = useState(null);
  const [isEditing, setIsEditing] = useState(false);
  const [errors, setErrors] = useState({});

  useEffect(() => {
    const loadProfile = async () => {
      const data = await getProfile();

      setProfile(data);
      setFormData(data);
    };

    loadProfile();
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;

    setFormData((previousData) => ({
      ...previousData,
      [name]: value,
    }));
  };

  const handleEdit = () => {
    setFormData(profile);
    setIsEditing(true);
  };

  const handleCancel = () => {
    setFormData(profile);
    setIsEditing(false);
  };

  const validateForm = () => {
    const errors = {};
    if (!formData.firstName.trim()) {
      errors.firstName = "First name is required";
    }

    if (!formData.lastName.trim()) {
      errors.lastName = "Last name is required";
    }

    if (formData.yearsOfExperience < 0 || isNaN(formData.yearsOfExperience) || formData.yearsOfExperience === "") {
      errors.yearsOfExperience = "Years of experience cannot be negative.";
    }

    return errors;
  };

  const handleSave = async () => {
    // Validate form data before sending the update request
    const validationErrors = validateForm();

    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      return;
    }

    await updateProfile({
      firstName: formData.firstName,
      lastName: formData.lastName,
      linkedInUrl: formData.linkedInUrl,
      gitHubUrl: formData.gitHubUrl,
      yearsOfExperience: Number(formData.yearsOfExperience),
    });

    const updatedProfile = await getProfile();

    setProfile(updatedProfile);
    setFormData(updatedProfile);
    setIsEditing(false);

    setErrors({});
  };

  if (!profile) {
    return <div className="profile-loading">Loading profile...</div>;
  }

  return (
    <div className="profile-container">
      <div className="profile-top">
        <div>
          <h1>My Profile</h1>
          <p>Manage your professional information</p>
        </div>

        {!isEditing && (
          <button className="edit-button" onClick={handleEdit}>
            Edit Profile
          </button>
        )}
      </div>

      <div className="profile-card profile-summary">
        <div className="profile-avatar">
          {profile.firstName.charAt(0)}
          {profile.lastName.charAt(0)}
        </div>

        <div className="profile-summary-info">
          <h2>
            {profile.firstName} {profile.lastName}
          </h2>

          <p>{profile.email}</p>

          <span>{profile.yearsOfExperience} years experience</span>
        </div>
      </div>

      <div className="profile-card">
        <div className="section-header">
          <div>
            <h2>Basic Details</h2>
            <p>Your basic contact and professional links</p>
          </div>
        </div>

        <div className="profile-grid">
          <div className="profile-field">
            <label>First Name</label>

            {isEditing ? (
              <>
                <input
                  name="firstName"
                  value={formData.firstName}
                  onChange={handleChange}
                />

                {errors.firstName && (
                  <span className="field-error">{errors.firstName}</span>
                )}
              </>
            ) : (
              <div className="field-value">{profile.firstName}</div>
            )}
          </div>

          <div className="profile-field">
            <label>Last Name</label>

            {isEditing ? (
              <>
                <input
                  name="lastName"
                  value={formData.lastName}
                  onChange={handleChange}
                />

                {errors.lastName && (
                  <span className="field-error">{errors.lastName}</span>
                )}
              </>
            ) : (
              <div className="field-value">{profile.lastName}</div>
            )}
          </div>

          <div className="profile-field full-width">
            <label>Email</label>

            <div className="field-value disabled-field">{profile.email}</div>
          </div>

          <div className="profile-field">
            <label>LinkedIn</label>

            {isEditing ? (
              <input
                name="linkedInUrl"
                value={formData.linkedInUrl ?? ""}
                onChange={handleChange}
                placeholder="https://linkedin.com/in/..."
              />
            ) : (
              <div className="field-value">
                {profile.linkedInUrl || "Not added"}
              </div>
            )}
          </div>

          <div className="profile-field">
            <label>GitHub</label>

            {isEditing ? (
              <input
                name="gitHubUrl"
                value={formData.gitHubUrl ?? ""}
                onChange={handleChange}
                placeholder="https://github.com/..."
              />
            ) : (
              <div className="field-value">
                {profile.gitHubUrl || "Not added"}
              </div>
            )}
          </div>
        </div>
      </div>

      <div className="profile-card">
        <div className="section-header">
          <div>
            <h2>Professional Details</h2>
            <p>Information about your professional experience</p>
          </div>
        </div>

        <div className="profile-grid">
          <div className="profile-field">
            <label>Years of Experience</label>

            {isEditing ? (
              <>
                <input
                  type="number"
                  name="yearsOfExperience"
                  value={formData.yearsOfExperience}
                  onChange={handleChange}
                  min="0"
                  step="0.1"
                />

                {errors.yearsOfExperience && (
                  <span className="field-error">
                    {errors.yearsOfExperience}
                  </span>
                )}
              </>
            ) : (
              <div className="field-value">
                {profile.yearsOfExperience} years
              </div>
            )}
          </div>
        </div>
      </div>

      {isEditing && (
        <div className="profile-actions">
          <button className="cancel-button" onClick={handleCancel}>
            Cancel
          </button>

          <button className="save-button" onClick={handleSave}>
            Save Changes
          </button>
        </div>
      )}
    </div>
  );
}

export default ProfilePage;
