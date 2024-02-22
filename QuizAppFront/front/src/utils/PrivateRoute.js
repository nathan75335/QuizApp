import {Navigate , Outlet} from "react-router-dom";

//Protected Routes with React Router v6
function PrivateRoutes(){
    let auth = {'token': false} 
    return(
        auth.token ? <Outlet/> : <Navigate to="/"/>
    )
}