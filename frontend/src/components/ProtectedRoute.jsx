import { useContext } from "react";
import { Navigate } from "react-router-dom";
import { AuthContext } from "../context/AuthContext";



function ProtectedRoute({ children }) {
    const {token} = useContext(AuthContext);
    if(!token){
        return <Navigate to="/"/>
    }


    return children;
}


export default ProtectedRoute;