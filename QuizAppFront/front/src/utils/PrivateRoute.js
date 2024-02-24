import {Navigate ,  Outlet} from "react-router-dom";


//Protected Routes with React Router v6
function PrivateRoutes(){

    //let aut = { 'tok': true}
    let auth = JSON.parse(localStorage.getItem('token'))

    return(
        auth? auth.token? <Outlet/> : <Navigate to="/" /> : <Navigate to="/" />
    )
}

export default PrivateRoutes