import { useEffect, useState } from "react";
import { getProfile } from "../api/profileApi";
import "./Profile.css";

function ProfilePage() {
  const [profile, setProfile] = useState(null);

  useEffect(() => {
    const loadProfile = async () => {
      try {
        const data = await getProfile();
        setProfile(data);
      } catch (error) {
        console.error("Error fetching profile:", error);
      }
    };
    loadProfile();
  }, []);

  if (!profile) {
    return <p>Loading profile...</p>;
  }

   return (
    <div className="profile-container">
      <h1>My Profile</h1>

      <div className="profile-card">
        <h2>Basic Details</h2>

        <div className="profile-field">
          <label>First Name</label>
          <p>{profile.firstName}</p>
        </div>

        <div className="profile-field">
          <label>Last Name</label>
          <p>{profile.lastName}</p>
        </div>

        <div className="profile-field">
          <label>Email</label>
          <p>{profile.email}</p>
        </div>

        <div className="profile-field">
          <label>LinkedIn</label>
          <p>{profile.linkedInUrl || "Not added"}</p>
        </div>

        <div className="profile-field">
          <label>GitHub</label>
          <p>{profile.gitHubUrl || "Not added"}</p>
        </div>
      </div>

      <div className="profile-card">
        <h2>Professional Details</h2>

        <div className="profile-field">
          <label>Years of Experience</label>
          <p>{profile.yearsOfExperience}</p>
        </div>
      </div>
    </div>
  );
}

export default ProfilePage;
