import { Outlet } from "react-router-dom"
import { Navbar } from "./components/Navbar"

export const NavbarLayout = () => {
  return (<>
    <Navbar />
    <Outlet />
  </>)
}