import { Outlet } from "react-router-dom"
import Modal from "../components/Modal"

export const ModalLayout = () => {

  return (
    <Modal>
      <Outlet />
    </Modal>
  )
}