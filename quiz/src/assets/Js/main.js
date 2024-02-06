import React, {useEffect}from 'react'

function main() {
    useEffect(() => {
        // Fonction fadeout
        
        function fadeout() {
            document.querySelector('.preloader').style.opacity = '0';
            document.querySelector('.preloader').style.display = 'none';
        }

        // Exécute fadeout après un délai de 500ms lorsque la fenêtre est chargée
        window.onload = function () {
            window.setTimeout(fadeout, 500);
        }

        // Gestion du scroll
        window.onscroll = function () {
            // Code de gestion du scroll
        };

        // Initialisation de WOW.js si nécessaire
        new WOW().init();

        // Gestion du clic sur le bouton mobile-menu-btn
        let navbarToggler = document.querySelector(".mobile-menu-btn");
        navbarToggler.addEventListener('click', function () {
            navbarToggler.classList.toggle("active");
        });

        // Gestion de l'activation du bouton portfolio-btn
        var elements = document.getElementsByClassName("portfolio-btn");
        for (var i = 0; i < elements.length; i++) {
            elements[i].onclick = function () {
                // Code de gestion de l'activation du bouton portfolio-btn
            };
        }
    }, []); // Le tableau vide [] indique que ce hook useEffect ne s'exécutera qu'une seule fois après le rendu initial

    return (
        <div>
            {/* Contenu de votre composant */}
        </div>
    );
}


export default main