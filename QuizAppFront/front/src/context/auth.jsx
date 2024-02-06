import { createContext, useContext } from "react"

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {

    const storeTokenInLocalStorage = (serverToken) =>{
        return localStorage.setItem('token', serverToken)
    }

    return <AuthContext.Provider value={{ storeTokenInLocalStorage}}>
                {children}
            </AuthContext.Provider>
}

export const useAuth = () => {
    const authContextValue = useContext(AuthContext)
    if(!(authContextValue)){
        throw new Error("useAth used outside of the Provider")
    }
    return authContextValue
}

