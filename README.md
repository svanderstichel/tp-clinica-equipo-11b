# 🏥 TP Clínica - Equipo 11B

Aplicación web para la **gestión integral de una clínica médica**, desarrollada en ASP.NET.  
Permite administrar **turnos, médicos, pacientes y especialidades**, con distintos niveles de acceso según el rol del usuario.

---

## 👥 Jerarquía de accesos

### 🧑‍💼 Administrador
Tiene acceso total al sistema. Puede:
- Administrar médicos y sus **especialidades**.
- Definir **turnos de trabajo**.
- Gestionar **pacientes** y **obras sociales**.
- Consultar y modificar **turnos**.
- Ver y editar su propio **perfil**.

### 💁‍♀️ Recepcionista
Cuenta con permisos intermedios. Puede:
- Administrar **pacientes** y **médicos**.
- Dar de alta, modificar o cancelar **turnos**.
- Ver y editar su propio **perfil**.

### 🩺 Médico
Posee acceso restringido. Puede:
- Ver **sus turnos asignados**.
- Modificar turnos para **agregar observaciones o diagnósticos**.
- Ver y editar su propio **perfil**.

---

## 🧭 Diseño de navegación

### 🔐 Login
- Permite el acceso al sistema según el tipo de usuario.

---

### 👑 Administrador
- **Perfil**
- **Médicos**
  - Especialidades
  - Turnos de trabajo
- **Pacientes**
  - Obras sociales
- **Turnos**

---

### 💼 Recepcionista
- **Perfil**
- **Médicos**
- **Pacientes**
- **Turnos**

---

### 🩺 Médico
- **Perfil**
- **Turnos**

---

## 🗂️ DER (Diagrama Entidad-Relación)

> *(Agregar imagen o enlace al DER aquí)*  
> Ejemplo:
> ```md
> <img width="404" height="710" alt="image" src="https://github.com/user-attachments/assets/f4b18ee3-3358-47dd-9604-5dd74eea4949" />
> ```

---

## ⚙️ Tecnologías utilizadas
- **ASP.NET Web Forms / C#**
- **SQL Server**
- **HTML5 / CSS / Bootstrap**
- **ADO.NET**
- **Git / GitHub**

## 🧩 Equipo 11B
> Proyecto académico - **Programación III - UTN**
