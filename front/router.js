import { createRouter, createWebHistory } from 'vue-router';
import Client from '@/components/Client/Client.vue';
import CreateClient from '@/components/Client/CreateClient.vue';
import EditClient from '@/components/Client/EditClient.vue';
import ArticleList from '@/components/Article/ArticleList.vue';
import CreateArticle from '@/components/Article/CreateArticle.vue';
import InterventionList from '@/components/Intervention/InterventionList.vue';
import CreateIntervention from '@/components/Intervention/CreateIntervention.vue';
import ReclamationList from '@/components/Reclamation/ReclamationList.vue';
import CreateReclamation from '@/components/Reclamation/CreateReclamation.vue';
import EditReclamation from '@/components/Reclamation/EditReclamation.vue';
import Piece from '@/components/Piece/Piece.vue';
import CreatePiece from '@/components/Piece/CreatePiece.vue';
import EditPiece from '@/components/Piece/EditPiece.vue';
import Login from '@/components/Authentification/Login.vue';
import registerUser from '@/components/Authentification/Inscription.vue';
import Role from '@/components/Authentification/Role.vue';
import DashboardAdmin from '@/components/Dashboard.vue';
import TechnicienList from '@/components/Technicien/TechnicienList.vue';
import CreateTechnicien from '@/components/Technicien/CreateTechnicien.vue';
import EditTechnicien from '@/components/Technicien/EditTechnicien.vue';

const routes = [
  { path: '/', name: 'Login', component: Login}, 

  { path: '/clients', name: 'Client', component: Client }, 
  { path: '/create-client', name: 'CreateClient', component: CreateClient }, 
  { path: '/edit-client/:id', name: 'EditClient', component: EditClient }, 

  { path: '/articles', name: 'ArticleList', component: ArticleList , meta: { requiresAuth: true } },
  { path: '/create-article', name: 'CreateArticle', component: CreateArticle },
  { path: '/edit-article/:id', name: 'EditArticle', component: CreateArticle },

  { path: '/interventions', name: 'InterventionList', component: InterventionList },
  { path: '/create-intervention', name: 'CreateIntervention', component: CreateIntervention },
  { path: '/edit-intervention/:id', name: 'EditIntervention', component: CreateIntervention },

  { path: '/reclamations', name: 'ReclamationList', component: ReclamationList },
  { path: '/create-reclamation', name: 'CreateReclamation', component: CreateReclamation },
  { path: '/edit-reclamation/:id', name: 'EditReclamation', component: EditReclamation },

  { path: '/pieces', name: 'Piece', component: Piece },
  { path: '/create-piece', name: 'CreatePiece', component: CreatePiece },
  { path: '/edit-piece/:id', name: 'EditPiece', component: EditPiece },

  { path: '/techniciens', name: 'TechnicienList', component: TechnicienList },
  { path: '/technicien/create', name: 'CreateTechnicien', component: CreateTechnicien },
  { path: '/technicien/edit/:id',name: 'EditTechnicien', component: EditTechnicien },

  { path: '/login', name: 'Login', component: Login },
  { path: '/inscription', name: 'Inscription', component: registerUser },
  { path: '/add-role', name: 'Role', component: Role},

  { path: '/dashboard', name: 'Dashboard', component: DashboardAdmin}

];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
