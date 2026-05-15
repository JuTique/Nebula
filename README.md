# Nebula
Proyecto académico desarrollado para la materia **Scripting – Ingeniería en Diseño de Entretenimiento Digital (UPB)**.

Nebula es un videojuego de plataformas 2D desarrollado en **Unity** utilizando el framework **Corgi Engine**.

El jugador controla a **Darius Holt**, un recolector enviado a explorar una estación minera abandonada en **Titán**, luna de Saturno. Durante la exploración descubrirá anomalías energéticas, enemigos hostiles y restos de una operación minera fallida.

---

# Tecnologías Utilizadas

- Unity Engine 2022.3 LTS
- C#
- Corgi Engine Framework
- Git / GitHub
- Visual Studio / Visual Studio Code

---

# Integrantes del Proyecto

- Stella Perez
- Juan Camilo Tique

---
## UML Class Diagram

![UML Diagram](UMLDiagram-Nebula.drawio.png)

---

# Entrega 2 – Diseño del Nivel 2

Se realizó el diseño manual del segundo nivel teniendo en cuenta:

- progresión de dificultad
- distribución de plataformas
- posicionamiento de enemigos
- ubicación estratégica de monedas

Posteriormente el nivel fue implementado en Unity utilizando **Tilemaps** y plataformas del **Corgi Engine**.

## Personalización Gráfica

Se diseñaron nuevos elementos visuales para el nivel 2 con una estética acorde a la estación minera.

### Fondo

El fondo representa una zona interna deteriorada de la estación minera, con predominio de sombras y ambiente de cueva.

### Plataformas

Las plataformas fueron diseñadas con una apariencia industrial para mantener coherencia con el entorno.

## Sistema de Monedas

Se implementaron monedas recolectables que representan **fragmentos de energía cristalizada provenientes de los reactores de la estación minera**.

## Sistema de Portales

Se implementaron **portales de transición de nivel** que permiten al jugador avanzar entre zonas de la estación minera.

Estos portales funcionan como puntos de conexión entre áreas del juego.

---

# Entrega 3 – Feedbacks y IA Básica

En esta entrega se implementaron sistemas de retroalimentación visual y sonora, además de enemigos con comportamiento básico mediante IA.

## Feedback del Easter Egg

Se integró un Easter Egg interactivo con retroalimentación mediante `MMFeedbacks`, permitiendo activar un evento visual y sonoro al recogerlo.

## IA Básica de Enemigos

Se configuraron enemigos con **AIBrain** utilizando un flujo simple de estados para patrulla, persecución y ataque.

Esta IA básica permite que los enemigos reaccionen al jugador sin requerir scripts personalizados complejos.

## Feedbacks

Se implementaron retroalimentaciones visuales, sonoras y de cámara mediante **MMFeedbacks**.

### Sonido

- música de fondo
- sonido al recolectar logros
- sonido en botones de interfaz

### Cámara

- sacudida por impacto
- retroalimentación durante ataques

### Animación

- escala y rebote en monedas
- animaciones de interfaz y ventanas emergentes

---

# Entrega 4 – Sistemas de Progresión y Combate

En esta entrega se añadieron sistemas que mejoran la progresión y la dificultad del juego.

## Sistema de Checkpoints

Se añadieron checkpoints para que el jugador reaparezca desde puntos seguros dentro del nivel al perder una vida.

Este sistema permite una progresión más fluida y reduce la frustración al repetir secciones extensas.

## Sistema de Armas

Se agregó la recolección de armas mediante prefabs interactivos, permitiendo al jugador obtener equipo al tocar objetos del escenario.

Esto se implementó usando el sistema de objetos recogibles de Corgi Engine.

## Sistema de Dificultad

Se desarrolló un selector de dificultad con tres modos configurables desde interfaz de usuario:

- fácil
- medio
- difícil

Cada dificultad modifica parámetros como:

- vida del jugador
- daño de enemigos
- cantidad de monedas obtenidas
- invulnerabilidad tras recibir daño
- temporizador de nivel
- agresividad de la IA enemiga

## Jefe Principal

Se implementó un jefe con comportamiento basado en **AIBrain** y una máquina de estados de 7 fases:

- idle
- patrol
- chase
- dash prepare
- dash attack
- cooldown
- retreat

Este sistema permite un combate más dinámico y escalonado durante el enfrentamiento final del nivel.

## Sistema de Logros

Se implementó un sistema de logros desbloqueables con ventana emergente al obtenerlos.

Los logros pueden visualizarse dentro de su propia pantalla de menú y se actualizan al cumplirse las condiciones de juego.

## Pantalla Game Over

Se implementó una pantalla de **Game Over** que se activa cuando el jugador pierde todas sus vidas.

Opciones disponibles:

- reiniciar el nivel
- volver al menú principal

---

## Diagramas del Sistema

Se realizaron diagramas de clases para representar la estructura general del proyecto y sus sistemas principales.


---

# Instalación y Configuración

Este proyecto está desarrollado con **Unity** y utiliza el framework **Corgi Engine**.

## Prerrequisitos

- Unity Hub  
- Unity **2022.3 LTS**
- Git
- Visual Studio Community o Visual Studio Code

---

## Clonar el Repositorio

```bash
cd tu-carpeta-de-proyectos
git clone https://github.com/xaca/scripting2026.git
cd scripting2026

```
---

## Recursos Adicionales / Additional Resources
Unity Documentation
Corgi Engine Documentation
Git Tutorial
