import {AuthContext} from "../context/AuthContext";
import {useContext} from "react";
function TestPage() 
{

    const auth = useContext(AuthContext);

    console.log("AuthContext:",auth);

    return (    
        <div>
            <h1>Test Page</h1>
        </div>
    );    
}


export default TestPage;