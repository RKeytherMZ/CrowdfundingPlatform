// URLs de la API
const API_URL = "http://localhost:5281/api/Projects";
const API_URL_STUDENTS = "http://localhost:5281/api/Students";
const API_URL_DONATIONS = "http://localhost:5281/api/Donations";

// Variables para manejar la visibilidad de las secciones

const loginContainer = document.getElementById("login-container");
const mainContent = document.getElementById("main-content");
const sectionView = document.getElementById("section-view");
const loginForm = document.getElementById("login-form");

// Función principal para mostrar la sección correcta
function showSection(section) {
    // Limpia el contenido antes de cargar una nueva sección
    sectionView.innerHTML = '';

    if (section === 'home') {
        sectionView.innerHTML = `
            <section id="home-section" class="container">
                <div class="card home-card">
                    <h2 class="home-title">Nuestra Misión: Empoderar el Futuro</h2>
                    <p class="home-intro">
                        En Éclat Foundation, creemos en el poder de la educación para transformar vidas. Somos una organización sin fines de lucro dedicada a conectar a estudiantes universitarios brillantes con las personas que quieren hacer la diferencia.
                    </p>
                    <div class="home-grid">
                        <div class="home-mission">
                            <i class="fas fa-graduation-cap home-icon"></i>
                            <h3>Educación Accesible</h3>
                            <p>
                                Facilitamos el acceso a la educación superior financiando proyectos de investigación, tesis y emprendimientos estudiantiles. Creemos que el talento no debería tener barreras económicas.
                            </p>
                        </div>
                        <div class="home-mission">
                            <i class="fas fa-seedling home-icon"></i>
                            <h3>Innovación y Crecimiento</h3>
                            <p>
                                Ayudamos a los jóvenes a convertir sus ideas en realidad. Cada proyecto de crowdfunding es una oportunidad para que los estudiantes innoven, crezcan y contribuyan al desarrollo de su comunidad.
                            </p>
                        </div>
                        <div class="home-mission">
                            <i class="fas fa-users home-icon"></i>
                            <h3>Comunidad y Conexión</h3>
                            <p>
                                Construimos un puente entre los futuros líderes y una red global de donantes. Juntos, creamos un ecosistema de apoyo donde la colaboración es la clave del éxito.
                            </p>
                        </div>
                    </div>
                    <div class="home-cta">
                        <p>Únete a nuestra causa y ayuda a forjar el futuro de la educación. Explora los proyectos o realiza una donación hoy mismo.</p>
                        <button onclick="showSection('projects')">Explora Proyectos</button>
                    </div>
                </div>
            </section>
        `;
    } else if (section === 'projects') {
        sectionView.innerHTML = `
            <section id="projects-section">
                <h1>Proyectos de Estudiantes</h1>
                <div id="projects-container"></div>
                <div class="form-container">
                    <h2>Crear Nuevo Proyecto</h2>
                    <form id="create-project-form">
                        <div>
                            <label for="title">Título:</label>
                            <input type="text" id="title" name="title" required>
                        </div>
                        <div>
                            <label for="description">Descripción:</label>
                            <textarea id="description" name="description" required></textarea>
                        </div>
                        <div>
                            <label for="fundingGoal">Meta de Financiamiento:</label>
                            <input type="number" id="fundingGoal" name="fundingGoal" step="0.01" required>
                        </div>
                        <div>
                            <label for="startDate">Fecha de Inicio:</label>
                            <input type="date" id="startDate" name="startDate" required>
                        </div>
                        <div>
                            <label for="endDate">Fecha de Fin:</label>
                            <input type="date" id="endDate" name="endDate" required>
                        </div>
                        <div>
                            <label for="studentIds">IDs de Estudiantes (separados por comas):</label>
                            <input type="text" id="studentIds" name="studentIds">
                        </div>
                        <div>
                            <label for="status">Estado:</label>
                            <select id="status" name="status">
                                <option value="Active">Activo</option>
                                <option value="Completed">Completado</option>
                                <option value="Closed">Cerrado</option>
                                <option value="Canceled">Cancelado</option>
                            </select>
                        </div>
                        <button type="submit">Crear Proyecto</button>
                    </form>
                </div>
            </section>
        `;
        setupProjectsLogic();
    } else if (section === 'students') {
        sectionView.innerHTML = `
            <section id="students-section">
                <h1>Gestión de Estudiantes</h1>
                <div id="students-container"></div>
                <div class="form-container">
                    <h2>Crear Nuevo Estudiante</h2>
                    <form id="create-student-form">
                        <div>
                            <label for="studentName">Nombre:</label>
                            <input type="text" id="studentName" name="name" required>
                        </div>
                        <div>
                            <label for="studentLastName">Apellido:</label>
                            <input type="text" id="studentLastName" name="lastName" required>
                        </div>
                        <div>
                            <label for="studentEmail">Email:</label>
                            <input type="email" id="studentEmail" name="email" required>
                        </div>
                        <div>
                            <label for="studentBio">Biografía:</label>
                            <textarea id="studentBio" name="bio" required></textarea>
                        </div>
                        <div>
                            <label for="studentAge">Edad:</label>
                            <input type="number" id="studentAge" name="age" required>
                        </div>
                        <div>
                            <label for="studentInstitution">Institución:</label>
                            <input type="text" id="studentInstitution" name="institution" required>
                        </div>
                        <button type="submit">Crear Estudiante</button>
                    </form>
                </div>
            </section>
        `;
        setupStudentsLogic();
    } else if (section === 'donations') {
        sectionView.innerHTML = `
            <section id="donations-section">
                <h1>Realizar una Donación</h1>
                <div class="form-container">
                    <h2>Formulario de Donación</h2>
                    <form id="donate-form">
                        <div>
                            <label for="projectId">ID del Proyecto:</label>
                            <input type="number" id="projectId" name="projectId" required readonly>
                        </div>
                        <div>
                            <label for="donorName">Tu Nombre:</label>
                            <input type="text" id="donorName" name="donorName" required>
                        </div>
                        <div>
                            <label for="amount">Monto de la Donación:</label>
                            <input type="number" id="amount" name="amount" step="0.01" required>
                        </div>
                        <button type="submit">Donar Ahora</button>
                    </form>
                </div>
                <hr>
                <h2>Proyectos Disponibles</h2>
                <div id="projects-to-donate"></div>
                <hr>
                <h2>Historial de Donaciones</h2>
                <div id="donations-list"></div>
            </section>
        `;
        
        setTimeout(() => {
            setupDonationsLogic();
        }, 10);
    }
}

// Lógica de inicio de sesión
loginForm.addEventListener("submit", (event) => {
    event.preventDefault();
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;
    
    // Aquí se verifica el usuario y la contraseña.
    // Usamos una contraseña más segura.
    if (username === "admin" && password === "MyS3cureP@ssword") {
        loginContainer.style.display = "none";
        mainContent.style.display = "block";
        // Mostrar la página de inicio por defecto
        showSection('home'); 
    } else {
        alert("Usuario o contraseña incorrectos.");
    }
});



// Lógica para el login (oculta el login y muestra el contenido principal)
loginForm.addEventListener("submit", (event) => {
    event.preventDefault();
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;
    if (username === "admin" && password === "MyS3cureP@ssword") {
        loginContainer.style.display = "none";
        mainContent.style.display = "block";
        showSection('projects'); // Muestra Proyectos por defecto
    } else {
        alert("Usuario o contraseña incorrectos.");
    }
});

// Lógica de Proyectos
async function fetchProjects() {
    try {
        const response = await fetch(API_URL);
        if (!response.ok) {
            throw new Error(`Error en la red: ${response.statusText}`);
        }
        const projects = await response.json();
        const projectsContainer = document.getElementById("projects-container");
        projectsContainer.innerHTML = '';
        projects.forEach(project => {
            const projectElement = document.createElement("div");
            projectElement.classList.add("project-card");
            projectElement.innerHTML = `
                <h2>${project.title}</h2>
                <p><strong>Descripción:</strong> ${project.description}</p>
                <p><strong>Meta de Financiamiento:</strong> $${project.fundingGoal}</p>
                <p><strong>Monto Recaudado:</strong> $${project.amountRaised}</p>
                <button class="delete-btn" data-id="${project.id}">Eliminar</button>
                <button class="edit-btn" data-id="${project.id}">Editar</button>
            `;
            projectsContainer.appendChild(projectElement);
        });
    } catch (error) {
        console.error("Hubo un problema con la petición:", error);
        const projectsContainer = document.getElementById("projects-container");
        projectsContainer.innerHTML = `<p style="color: red;">Error al cargar los proyectos. ¿Está la API funcionando?</p>`;
    }
}

function setupProjectsLogic() {
    fetchProjects();

    const createProjectForm = document.getElementById("create-project-form");
    if(createProjectForm) {
        createProjectForm.addEventListener("submit", async (event) => {
            event.preventDefault();
            const title = document.getElementById("title").value;
            const description = document.getElementById("description").value;
            const fundingGoal = parseFloat(document.getElementById("fundingGoal").value);
            const startDate = document.getElementById("startDate").value;
            const endDate = document.getElementById("endDate").value;
            const studentIds = document.getElementById("studentIds").value
                .split(",")
                .map(id => parseInt(id.trim()))
                .filter(id => !isNaN(id));
            const status = document.getElementById("status").value;
            const newProjectData = {
                title,
                description,
                fundingGoal,
                startDate: new Date(startDate).toISOString(),
                endDate: new Date(endDate).toISOString(),
                studentIds,
                status
            };
            const editingId = createProjectForm.dataset.editingId;
            try {
                let response;
                if (editingId) {
                    response = await fetch(`${API_URL}/${editingId}`, {
                        method: "PUT",
                        headers: { "Content-Type": "application/json" },
                        body: JSON.stringify(newProjectData),
                    });
                } else {
                    response = await fetch(API_URL, {
                        method: "POST",
                        headers: { "Content-Type": "application/json" },
                        body: JSON.stringify(newProjectData),
                    });
                }
                if (!response.ok) {
                    throw new Error(`Error en la petición: ${response.statusText}`);
                }
                await fetchProjects();
                alert(`¡Proyecto ${editingId ? 'actualizado' : 'creado'} exitosamente!`);
                createProjectForm.reset();
                delete createProjectForm.dataset.editingId;
                document.querySelector("#create-project-form button").textContent = "Crear Proyecto";
            } catch (error) {
                console.error("Hubo un problema con la petición:", error);
                alert(`Error: ${error.message}`);
            }
        });
    }

    const projectsContainer = document.getElementById("projects-container");
    if(projectsContainer) {
        projectsContainer.addEventListener("click", async (event) => {
            if (event.target.classList.contains("delete-btn")) {
                const projectId = event.target.dataset.id;
                if (confirm(`¿Estás seguro de que quieres eliminar el proyecto con ID ${projectId}?`)) {
                    try {
                        const response = await fetch(`${API_URL}/${projectId}`, {
                            method: "DELETE",
                        });
                        if (!response.ok) {
                            throw new Error(`Error al eliminar el proyecto: ${response.statusText}`);
                        }
                        await fetchProjects();
                        alert("¡Proyecto eliminado exitosamente!");
                    } catch (error) {
                        console.error("Hubo un problema con la petición DELETE:", error);
                        alert(`Error: ${error.message}`);
                    }
                }
            } else if (event.target.classList.contains("edit-btn")) {
                const projectId = event.target.dataset.id;
                try {
                    const response = await fetch(`${API_URL}/${projectId}`);
                    const projectToEdit = await response.json();
                    const createProjectForm = document.getElementById("create-project-form");
                    document.getElementById("title").value = projectToEdit.title;
                    document.getElementById("description").value = projectToEdit.description;
                    document.getElementById("fundingGoal").value = projectToEdit.fundingGoal;
                    document.getElementById("startDate").value = new Date(projectToEdit.startDate).toISOString().split('T')[0];
                    document.getElementById("endDate").value = new Date(projectToEdit.endDate).toISOString().split('T')[0];
                    document.getElementById("studentIds").value = projectToEdit.students.map(s => s.id).join(', ');
                    document.getElementById("status").value = projectToEdit.status;
                    createProjectForm.dataset.editingId = projectId;
                    document.querySelector("#create-project-form button").textContent = "Actualizar Proyecto";
                } catch (error) {
                    console.error("Error al cargar datos para edición:", error);
                    alert(`Error al cargar datos del proyecto: ${error.message}`);
                }
            }
        });
    }
}

// Lógica de Estudiantes
async function fetchStudents() {
    try {
        const response = await fetch(API_URL_STUDENTS);
        if (!response.ok) {
            throw new Error(`Error en la red: ${response.statusText}`);
        }
        const students = await response.json();
        const studentsContainer = document.getElementById("students-container");
        studentsContainer.innerHTML = '';
        students.forEach(student => {
            const studentElement = document.createElement("div");
            studentElement.classList.add("student-card");
            studentElement.innerHTML = `
                <h3>${student.name} ${student.lastName}</h3>
                <p><strong>Email:</strong> ${student.email}</p>
                <p><strong>Edad:</strong> ${student.age}</p>
                <p><strong>Institución:</strong> ${student.institution}</p>
                <button class="delete-student-btn" data-id="${student.id}">Eliminar</button>
                <button class="edit-student-btn" data-id="${student.id}">Editar</button>
            `;
            studentsContainer.appendChild(studentElement);
        });
    } catch (error) {
        console.error("Hubo un problema con la petición de estudiantes:", error);
        const studentsContainer = document.getElementById("students-container");
        studentsContainer.innerHTML = `<p style="color: red;">Error al cargar los estudiantes. ¿Está la API funcionando?</p>`;
    }
}

function setupStudentsLogic() {
    fetchStudents();
    
    // Asigna el event listener al formulario de creación/edición
    const createStudentForm = document.getElementById("create-student-form");
    if(createStudentForm) {
        createStudentForm.addEventListener("submit", async (event) => {
            event.preventDefault();
            const name = document.getElementById("studentName").value;
            const lastName = document.getElementById("studentLastName").value;
            const email = document.getElementById("studentEmail").value;
            const bio = document.getElementById("studentBio").value;
            const age = parseInt(document.getElementById("studentAge").value);
            const institution = document.getElementById("studentInstitution").value;
            
            const newStudentData = { name, lastName, email, bio, age, institution };

            // Verifica si el formulario tiene un ID de edición
            const editingId = createStudentForm.dataset.editingId;
            try {
                let response;
                if (editingId) {
                    // Lógica para ACTUALIZAR (petición PUT)
                    response = await fetch(`${API_URL_STUDENTS}/${editingId}`, {
                        method: "PUT",
                        headers: { "Content-Type": "application/json" },
                        body: JSON.stringify(newStudentData),
                    });
                } else {
                    // Lógica para CREAR (petición POST)
                    response = await fetch(API_URL_STUDENTS, {
                        method: "POST",
                        headers: { "Content-Type": "application/json" },
                        body: JSON.stringify(newStudentData),
                    });
                }

                if (!response.ok) {
                    throw new Error(`Error en la petición: ${response.statusText}`);
                }

                await fetchStudents();
                alert(`¡Estudiante ${editingId ? 'actualizado' : 'creado'} exitosamente!`);
                
                // Restablece el formulario y el botón después de la operación
                createStudentForm.reset();
                delete createStudentForm.dataset.editingId;
                document.querySelector("#create-student-form button").textContent = "Crear Estudiante";
                
            } catch (error) {
                console.error("Hubo un problema con la petición:", error);
                alert(`Error: ${error.message}`);
            }
        });
    }



    // Lógica para manejar los clics en los botones de "Eliminar" y "Editar"
    const studentsContainer = document.getElementById("students-container");
    if(studentsContainer) {
        studentsContainer.addEventListener("click", async (event) => {
            if (event.target.classList.contains("delete-student-btn")) {
                const studentId = event.target.dataset.id;
                if (confirm(`¿Estás seguro de que quieres eliminar al estudiante con ID ${studentId}?`)) {
                    try {
                        const response = await fetch(`${API_URL_STUDENTS}/${studentId}`, {
                            method: "DELETE",
                        });
                        if (!response.ok) {
                            throw new Error(`Error al eliminar al estudiante: ${response.statusText}`);
                        }
                        await fetchStudents();
                        alert("¡Estudiante eliminado exitosamente!");
                    } catch (error) {
                        console.error("Hubo un problema con la petición DELETE de estudiantes:", error);
                        alert(`Error: ${error.message}`);
                    }
                }
            } else if (event.target.classList.contains("edit-student-btn")) {
                const studentId = event.target.dataset.id;
                try {
                    // Obtiene los datos del estudiante para llenar el formulario
                    const response = await fetch(`${API_URL_STUDENTS}/${studentId}`);
                    const studentToEdit = await response.json();
                    
                    const createStudentForm = document.getElementById("create-student-form");
                    document.getElementById("studentName").value = studentToEdit.name;
                    document.getElementById("studentLastName").value = studentToEdit.lastName;
                    document.getElementById("studentEmail").value = studentToEdit.email;
                    document.getElementById("studentBio").value = studentToEdit.bio;
                    document.getElementById("studentAge").value = studentToEdit.age;
                    document.getElementById("studentInstitution").value = studentToEdit.institution;

                    // Guarda el ID del estudiante en el formulario para usarlo en la actualización
                    createStudentForm.dataset.editingId = studentId;
                    document.querySelector("#create-student-form button").textContent = "Actualizar Estudiante";
                } catch (error) {
                    console.error("Error al cargar datos para edición:", error);
                    alert(`Error al cargar datos del estudiante: ${error.message}`);
                }
            }
        });
    }
}

function setupStudentsLogic() {
    fetchStudents();
    const createStudentForm = document.getElementById("create-student-form");
    if(createStudentForm) {
        createStudentForm.addEventListener("submit", async (event) => {
            event.preventDefault();
            const name = document.getElementById("studentName").value;
            const lastName = document.getElementById("studentLastName").value;
            const email = document.getElementById("studentEmail").value;
            const bio = document.getElementById("studentBio").value;
            const age = parseInt(document.getElementById("studentAge").value);
            const institution = document.getElementById("studentInstitution").value;
            const newStudentData = { name, lastName, email, bio, age, institution };

            const editingId = createStudentForm.dataset.editingId;
            try {
                let response;
                if (editingId) {
                    response = await fetch(`${API_URL_STUDENTS}/${editingId}`, {
                        method: "PUT",
                        headers: { "Content-Type": "application/json" },
                        body: JSON.stringify(newStudentData),
                    });
                } else {
                    response = await fetch(API_URL_STUDENTS, {
                        method: "POST",
                        headers: { "Content-Type": "application/json" },
                        body: JSON.stringify(newStudentData),
                    });
                }

                if (!response.ok) {
                    throw new Error(`Error en la petición: ${response.statusText}`);
                }
                await fetchStudents();
                alert(`¡Estudiante ${editingId ? 'actualizado' : 'creado'} exitosamente!`);
                createStudentForm.reset();
                delete createStudentForm.dataset.editingId;
                document.querySelector("#create-student-form button").textContent = "Crear Estudiante";
            } catch (error) {
                console.error("Hubo un problema con la petición:", error);
                alert(`Error: ${error.message}`);
            }
        });
    }

    const studentsContainer = document.getElementById("students-container");
    if(studentsContainer) {
        studentsContainer.addEventListener("click", async (event) => {
            if (event.target.classList.contains("delete-student-btn")) {
                const studentId = event.target.dataset.id;
                if (confirm(`¿Estás seguro de que quieres eliminar al estudiante con ID ${studentId}?`)) {
                    try {
                        const response = await fetch(`${API_URL_STUDENTS}/${studentId}`, {
                            method: "DELETE",
                        });
                        if (!response.ok) {
                            throw new Error(`Error al eliminar al estudiante: ${response.statusText}`);
                        }
                        await fetchStudents();
                        alert("¡Estudiante eliminado exitosamente!");
                    } catch (error) {
                        console.error("Hubo un problema con la petición DELETE de estudiantes:", error);
                        alert(`Error: ${error.message}`);
                    }
                }
            } else if (event.target.classList.contains("edit-student-btn")) {
                const studentId = event.target.dataset.id;
                try {
                    const response = await fetch(`${API_URL_STUDENTS}/${studentId}`);
                    const studentToEdit = await response.json();
                    
                    const createStudentForm = document.getElementById("create-student-form");
                    document.getElementById("studentName").value = studentToEdit.name;
                    document.getElementById("studentLastName").value = studentToEdit.lastName;
                    document.getElementById("studentEmail").value = studentToEdit.email;
                    document.getElementById("studentBio").value = studentToEdit.bio;
                    document.getElementById("studentAge").value = studentToEdit.age;
                    document.getElementById("studentInstitution").value = studentToEdit.institution;
                    createStudentForm.dataset.editingId = studentId;
                    document.querySelector("#create-student-form button").textContent = "Actualizar Estudiante";
                } catch (error) {
                    console.error("Error al cargar datos para edición:", error);
                    alert(`Error al cargar datos del estudiante: ${error.message}`);
                }
            }
        });
    }
}


// Lógica de Donaciones
function setupDonationsLogic() {
    async function fetchDonations() {
        try {
            const response = await fetch(API_URL_DONATIONS);
            if (!response.ok) throw new Error("Error al cargar las donaciones.");
            const donations = await response.json();
            
            const donationsContainer = document.getElementById("donations-list");
            if(donationsContainer) {
                donationsContainer.innerHTML = '';
                donations.forEach(donation => {
                    const donationElement = document.createElement("div");
                    donationElement.classList.add("donation-card");
                    donationElement.innerHTML = `
                        <h4>Donación al Proyecto ${donation.projectId}</h4>
                        <p><strong>Donante:</strong> ${donation.donorName}</p>
                        <p><strong>Monto:</strong> $${donation.amount}</p>
                        <button class="edit-donation-btn" data-id="${donation.id}">Editar</button>
                        <button class="delete-donation-btn" data-id="${donation.id}">Eliminar</button>
                    `;
                    donationsContainer.appendChild(donationElement);
                });
            }
        } catch (error) {
            console.error("Error cargando donaciones:", error);
        }
    }

    async function listProjectsForDonation() {
        try {
            const response = await fetch(API_URL);
            if (!response.ok) throw new Error("Error al cargar proyectos.");
            const projects = await response.json();
            
            const projectsContainer = document.getElementById("projects-to-donate");
            if(projectsContainer) {
                projectsContainer.innerHTML = '';
                projects.forEach(project => {
                    const projectElement = document.createElement("div");
                    projectElement.classList.add("project-card");
                    projectElement.innerHTML = `
                        <h3>${project.title}</h3>
                        <p><strong>Descripción:</strong> ${project.description}</p>
                        <p><strong>Meta de Financiamiento:</strong> $${project.fundingGoal}</p>
                        <p><strong>Monto Recaudado:</strong> $${project.amountRaised}</p>
                        <button class="donate-btn" data-id="${project.id}">Donar a este Proyecto</button>
                    `;
                    projectsContainer.appendChild(projectElement);
                });

                projectsContainer.addEventListener("click", (event) => {
                    if (event.target.classList.contains("donate-btn")) {
                        const projectId = event.target.dataset.id;
                        document.getElementById("projectId").value = projectId;
                    }
                });
            }
        } catch (error) {
            console.error("Error listando proyectos para donación:", error);
        }
    }
    
    const donateForm = document.getElementById("donate-form");
    if(donateForm) {
        donateForm.addEventListener("submit", async (event) => {
            event.preventDefault();

            const projectId = parseInt(document.getElementById("projectId").value);
            const donorName = document.getElementById("donorName").value;
            const amount = parseFloat(document.getElementById("amount").value);

            const donationData = {
                projectId,
                donorName,
                amount
            };

            const editingId = donateForm.dataset.editingId;
            let response;
            
            try {
                if (editingId) {
                    response = await fetch(`${API_URL_DONATIONS}/${editingId}`, {
                        method: "PUT",
                        headers: { "Content-Type": "application/json" },
                        body: JSON.stringify(donationData),
                    });
                } else {
                    response = await fetch(API_URL_DONATIONS, {
                        method: "POST",
                        headers: { "Content-Type": "application/json" },
                        body: JSON.stringify(donationData),
                    });
                }

                if (!response.ok) {
                    throw new Error(`Error al procesar la donación: ${response.statusText}`);
                }

                alert(`¡Donación ${editingId ? 'actualizada' : 'creada'} exitosamente!`);
                donateForm.reset();
                delete donateForm.dataset.editingId;
                document.querySelector("#donate-form button").textContent = "Donar Ahora";
                
                showSection('donations');
                
            } catch (error) {
                console.error("Hubo un problema con la donación:", error);
                alert(`Error al realizar la donación: ${error.message}`);
            }
        });
    }

    const donationsContainer = document.getElementById("donations-list");
    if(donationsContainer) {
        donationsContainer.addEventListener("click", async (event) => {
            if (event.target.classList.contains("delete-donation-btn")) {
                const donationId = event.target.dataset.id;
                if (confirm(`¿Estás seguro de que quieres eliminar esta donación?`)) {
                    try {
                        const response = await fetch(`${API_URL_DONATIONS}/${donationId}`, {
                            method: "DELETE",
                        });
                        if (!response.ok) throw new Error("Error al eliminar la donación.");
                        alert("¡Donación eliminada exitosamente!");
                        showSection('donations');
                    } catch (error) {
                        console.error("Error eliminando donación:", error);
                        alert(`Error: ${error.message}`);
                    }
                }
            } else if (event.target.classList.contains("edit-donation-btn")) {
                const donationId = event.target.dataset.id;
                const donateForm = document.getElementById("donate-form");
                try {
                    const response = await fetch(`${API_URL_DONATIONS}/${donationId}`);
                    if (!response.ok) throw new Error("Error al cargar la donación para editar.");
                    const donationToEdit = await response.json();
                    
                    document.getElementById("projectId").value = donationToEdit.projectId;
                    document.getElementById("donorName").value = donationToEdit.donorName;
                    document.getElementById("amount").value = donationToEdit.amount;

                    donateForm.dataset.editingId = donationId;
                    document.querySelector("#donate-form button").textContent = "Actualizar Donación";

                } catch (error) {
                    console.error("Error al cargar datos para edición:", error);
                    alert(`Error: ${error.message}`);
                }
            }
        });
    }

    listProjectsForDonation();
    fetchDonations();
}

