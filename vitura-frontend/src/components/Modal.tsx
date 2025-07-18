import type { PropsWithChildren } from 'react';
import { Modal as BootstrapModal } from 'react-bootstrap';

const Modal = (props: PropsWithChildren) => {


  return (
    <div
      className="modal show"
      style={{ display: 'block', position: 'initial' }}
    >
      <BootstrapModal show={true}>
        <BootstrapModal.Body>
          {props.children}
        </BootstrapModal.Body>
      </BootstrapModal>
    </div>

  );

};

export default Modal;
