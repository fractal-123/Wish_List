import React from "react";
import "./modal.css"
import CreateWishForm from "../components/CreateWishForm";



function Modal  ({active, setActive, onCreate})  {
    

    
    return(
        <div className={active ? "modal active" : "modal" } onClick={() => setActive(false)}>
            <div className="modal__content" onClick={e=>e.stopPropagation()}>
                <CreateWishForm onCreate = {onCreate}/>
            </div>
            
        </div>
    );
}

export default Modal;