import { React } from 'react';

import { Link } from "react-router-dom";

function Start() {

    return (
        <div className=" flex flex-col justify-center min-h-screen items-center text-3xl">
            <p className='font-bold'>Главная страница{" "}  </p>

            <Link
                to="/auth/login"
                className='hover:underline'
            >
                Войти
            </Link>

        </div>


    )
}



export default Start;