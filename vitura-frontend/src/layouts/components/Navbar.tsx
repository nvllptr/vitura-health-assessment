import { Navbar as BootstrapNavbar, Container } from "react-bootstrap"
import reactLogo from "../../assets/react.svg"
export const Navbar = () => {

  return (<>
    <BootstrapNavbar bg="light" data-bs-theme="light" className="mb-4 shadow-sm">
      <Container>
        <BootstrapNavbar.Brand href="/" className="d-flex">
          <img src={reactLogo} className="me-2" />
          Home
        </BootstrapNavbar.Brand>
      </Container>
    </BootstrapNavbar>
  </>)
}
