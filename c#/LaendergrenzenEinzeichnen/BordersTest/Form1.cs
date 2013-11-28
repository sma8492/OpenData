﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace BordersTest
{
    public partial class Form1 : Form
    {
        Image _drawArea;
        string[] _infos;
        int width = 21600;
        int height = 10800;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _infos = File.ReadAllLines("borders.csv");
            _drawArea = Bitmap.FromFile("world.jpg");
            
            pictureBox1.Image = _drawArea;
            //textBox1.Text = "POLYGON ((-65.190201 -22.09473,-65.598892 -22.100002,-65.657501 -22.108891,-65.734177 -22.113335,-65.748062 -22.111668,-65.753891 -22.110001,-65.763901 -22.105278,-65.81279 -22.071392,-65.867508 -22.005558,-65.926117 -21.933334,-66.077515 -21.831947,-66.194733 -21.788334,-66.223007 -21.780521,-66.234436 -21.790314,-66.238068 -21.803612,-66.263062 -21.902225,-66.281952 -21.978058,-66.291122 -22.031948,-66.291397 -22.038612,-66.306946 -22.076946,-66.345383 -22.116631,-66.402237 -22.134167,-66.49556 -22.161114,-66.559723 -22.178337,-66.616394 -22.191948,-66.688904 -22.196114,-66.736679 -22.227501,-66.771393 -22.375,-66.774734 -22.426945,-66.850281 -22.453056,-66.926392 -22.478058,-67.022507 -22.523891,-67.018066 -22.573891,-67.013062 -22.625557,-67.012222 -22.64278,-67.123062 -22.718056,-67.125839 -22.721111,-67.183624 -22.821667,-67.335007 -22.852779,-67.5 -22.885439,-67.579178 -22.901112,-67.793335 -22.878056,-67.876404 -22.828056,-67.884171 -22.71278,-67.851395 -22.560558,-67.848068 -22.549168,-67.886673 -22.432781,-67.894455 -22.420002,-67.932785 -22.300282,-67.923889 -22.280281,-67.921951 -22.267502,-67.922226 -22.241947,-67.923065 -22.236389,-67.943619 -22.107224,-67.945282 -22.102222,-67.972778 -22.06028,-67.996948 -22.046947,-68.084457 -21.966946,-68.085846 -21.95639,-68.087509 -21.913059,-68.086121 -21.88028,-68.087509 -21.842781,-68.090561 -21.820004,-68.102783 -21.753056,-68.107513 -21.737503,-68.121948 -21.698059,-68.133347 -21.675282,-68.14418 -21.658611,-68.170013 -21.627781,-68.183624 -21.613056,-68.188614 -21.606392,-68.188614 -21.296947,-68.229813 -21.233204,-68.421112 -20.939167,-68.426956 -20.938614,-68.453613 -20.939445,-68.478897 -20.941669,-68.5 -20.939445,-68.511398 -20.935837,-68.527237 -20.929169,-68.536392 -20.923615,-68.543625 -20.916668,-68.550568 -20.909447,-68.55806 -20.896389,-68.557693 -20.894451,-68.560013 -20.891392,-68.565567 -20.870281,-68.567505 -20.742226,-68.565292 -20.730003,-68.559723 -20.720837,-68.532501 -20.691113,-68.525284 -20.68417,-68.509171 -20.671669,-68.476959 -20.654724,-68.468903 -20.648613,-68.465836 -20.644726,-68.463898 -20.639168,-68.464172 -20.633057,-68.466675 -20.628891,-68.473343 -20.621391,-68.492508 -20.604725,-68.549454 -20.567501,-68.570847 -20.558891,-68.599731 -20.550003,-68.621674 -20.541946,-68.637222 -20.535278,-68.661957 -20.523056,-68.684723 -20.509724,-68.697235 -20.500278,-68.724731 -20.470837,-68.739182 -20.450279,-68.749451 -20.433056,-68.753067 -20.423058,-68.756958 -20.406948,-68.758896 -20.389725,-68.757507 -20.376114,-68.753067 -20.366112,-68.749725 -20.362225,-68.741959 -20.355835,-68.728058 -20.348614,-68.703613 -20.338058,-68.721115 -20.237782,-68.760559 -20.139725,-68.770279 -20.134724,-68.774445 -20.131668,-68.781113 -20.124447,-68.783615 -20.120003,-68.787231 -20.110001,-68.786667 -20.103336,-68.784729 -20.097778,-68.781952 -20.093334,-68.775284 -20.085556,-68.766953 -20.080002,-68.650558 -20.056667,-68.618622 -20.050835,-68.611954 -20.050556,-68.593338 -20.054726,-68.587784 -20.056667,-68.581116 -20.057781,-68.574448 -20.057503,-68.56778 -20.042225,-68.523346 -19.916389,-68.566956 -19.833889,-68.626114 -19.785835,-68.682236 -19.74778,-68.69278 -19.743614,-68.696945 -19.740559,-68.699448 -19.736115,-68.699722 -19.730003,-68.689728 -19.707226,-68.685562 -19.701389,-68.683624 -19.698891,-68.601959 -19.60778,-68.572556 -19.56654,-68.551392 -19.539722,-68.45195 -19.44389,-68.441116 -19.440556,-68.4375 -19.437225,-68.4375 -19.430279,-68.440842 -19.42028,-68.44751 -19.412502,-68.486389 -19.374168,-68.496948 -19.363892,-68.546951 -19.321945,-68.555557 -19.316669,-68.580002 -19.304726,-68.585281 -19.30278,-68.608337 -19.297226,-68.633621 -19.286945,-68.650848 -19.277225,-68.654449 -19.273891,-68.662231 -19.260834,-68.740845 -19.17778,-68.782501 -19.141945,-68.89473 -19.070278,-68.902237 -19.063335,-68.907791 -19.055279,-68.965836 -18.953056,-68.932785 -18.882778,-68.951401 -18.845837,-69.000565 -18.743057,-69.024445 -18.658611,-69.029175 -18.611389,-69.032501 -18.560001,-69.025558 -18.507504,-69.022781 -18.489723,-69.02417 -18.477222,-69.026947 -18.466393,-69.03334 -18.451946,-69.038345 -18.443058,-69.041122 -18.438892,-69.056122 -18.418892,-69.059723 -18.415558,-69.069168 -18.403893,-69.073898 -18.395,-69.075562 -18.389446,-69.085556 -18.285835,-69.08667 -18.239445,-69.087509 -18.233334,-69.091675 -18.223614,-69.098068 -18.216114,-69.112228 -18.202225,-69.116669 -18.199448,-69.131119 -18.185837,-69.139725 -18.173336,-69.147507 -18.160278,-69.149734 -18.155556,-69.150284 -18.14917,-69.148056 -18.137779,-69.142792 -18.128891,-69.136398 -18.121391,-69.132782 -18.117779,-69.120285 -18.109169,-69.115845 -18.106392,-69.105835 -18.102222,-69.084167 -18.088612,-69.080566 -18.085281,-69.074722 -18.077225,-69.071671 -18.059448,-69.071671 -18.038891,-69.074936 -18.037922,-69.127792 -18.030281,-69.13945 -18.0275,-69.287231 -17.982502,-69.291672 -17.979725,-69.298889 -17.973057,-69.303345 -17.963337,-69.308899 -17.948059,-69.315292 -17.926945,-69.321396 -17.891945,-69.318069 -17.833057,-69.318619 -17.820004,-69.320007 -17.814445,-69.324173 -17.804726,-69.330566 -17.790279,-69.35556 -17.745556,-69.376114 -17.726948,-69.483612 -17.635559,-69.490845 -17.63028,-69.499725 -17.50528,-69.500565 -17.426945,-69.501114 -17.378891,-69.533615 -17.347778,-69.590836 -17.29528,-69.656189 -17.287247,-69.618896 -17.214725,-69.592789 -17.184723,-69.537781 -17.134167,-69.525284 -17.125557,-69.473343 -17.095558,-69.468613 -17.093613,-69.463348 -17.094448,-69.451401 -17.103336,-69.446396 -17.102779,-69.406403 -17.072224,-69.388336 -17.055,-69.385559 -17.050835,-69.322235 -16.928337,-69.319168 -16.924168,-69.191956 -16.778057,-69.115845 -16.71389,-69.104446 -16.711391,-69.094452 -16.707226,-69.05751 -16.6875,-69.0439 -16.68,-69.018066 -16.663612,-69.011124 -16.656948,-69.002304 -16.643761,-69.007538 -16.636505,-69.021118 -16.622223,-69.025284 -16.619167,-69.031403 -16.611946,-69.03389 -16.606945,-69.037506 -16.59639,-69.041122 -16.554169,-69.041672 -16.541115,-69.03418 -16.473057,-68.990845 -16.419724,-68.840561 -16.35667,-68.826126 -16.351391,-68.82251 -16.339725,-68.823334 -16.327778,-68.824448 -16.321667,-68.826675 -16.316113,-68.830841 -16.306393,-68.833618 -16.302502,-68.840836 -16.295559,-68.848618 -16.289169,-68.960556 -16.212223,-68.965012 -16.209446,-68.970001 -16.2075,-68.977234 -16.207226,-69.040283 -16.206947,-69.046677 -16.2075,-69.051682 -16.209724,-69.0625 -16.220001,-69.068344 -16.228058,-69.072784 -16.230835,-69.079178 -16.231392,-69.134171 -16.223614,-69.145844 -16.220837,-69.150558 -16.218613,-69.15918 -16.213058,-69.162781 -16.209724,-69.166397 -16.206112,-69.211945 -16.160557,-69.214737 -16.156391,-69.216675 -16.15139,-69.420013 -15.625,-69.421951 -15.618057,-69.332504 -15.43889,-69.268341 -15.326946,-69.201401 -15.264723,-69.193344 -15.258612,-69.18779 -15.258612,-69.182236 -15.26,-69.172226 -15.264168,-69.165848 -15.265001,-69.15918 -15.264168,-69.153625 -15.263056,-69.14418 -15.258335,-69.137787 -15.250557,-69.136948 -15.245834,-69.136124 -15.230001,-69.138062 -15.225279,-69.170837 -15.187778,-69.197784 -15.158611,-69.295013 -15.079445,-69.375839 -14.978334,-69.381393 -14.970001,-69.384171 -14.958889,-69.384171 -14.951946,-69.367233 -14.808613,-69.366394 -14.802502,-69.364182 -14.797779,-69.361389 -14.793612,-69.350571 -14.783335,-69.336395 -14.77639,-69.310562 -14.766945,-69.248901 -14.6875,-69.248611 -14.654167,-69.244736 -14.61639,-69.241669 -14.605278,-69.236679 -14.589445,-69.234451 -14.584723,-69.228897 -14.576389,-69.11557 -14.484167,-68.991394 -14.390278,-68.984451 -14.383335,-68.9814 -14.379168,-68.979446 -14.374445,-68.979172 -14.3675,-68.982224 -14.356668,-68.993347 -14.34,-68.996948 -14.33639,-69.001953 -14.334167,-69.006958 -14.333612,-69.005569 -14.254168,-68.999176 -14.243334,-68.988617 -14.233057,-68.984177 -14.230278,-68.967789 -14.225557,-68.950012 -14.222223,-68.912781 -14.216946,-68.864456 -14.208889,-68.859451 -14.206667,-68.855835 -14.203335,-68.853058 -14.199167,-68.852234 -14.193056,-68.854172 -14.174446,-68.891113 -14.043612,-68.895569 -14.03389,-68.898056 -14.029724,-68.909729 -14.02,-68.93251 -14.007502,-68.94223 -14.003334,-68.957779 -13.990835,-68.964172 -13.983334,-68.972778 -13.970835,-68.977509 -13.961668,-69.001678 -13.839445,-69.014175 -13.791113,-69.06279 -13.707779,-69.029449 -13.644445,-69.022507 -13.644445,-69.018066 -13.641668,-69.014725 -13.638334,-69.011673 -13.634167,-68.979172 -13.566113,-68.961945 -13.513056,-68.960556 -13.500557,-68.959457 -13.452778,-68.960556 -13.272501,-68.968338 -13.166113,-68.968903 -13.103334,-68.968063 -13.09,-68.963348 -13.026669,-68.97168 -13.007223,-68.975006 -12.996668,-68.974457 -12.869722,-68.973618 -12.863335,-68.97084 -12.859167,-68.922226 -12.802778,-68.881668 -12.75889,-68.877228 -12.756111,-68.815567 -12.733057,-68.768341 -12.644167,-68.743622 -12.584723,-68.673904 -12.50115,-68.677505 -12.495834,-68.698624 -12.454168,-68.736389 -12.378056,-68.749451 -12.350279,-68.835556 -12.176945,-68.88028 -12.086945,-68.922501 -12.003613,-68.92807 -11.993057,-68.95723 -11.944723,-68.987228 -11.896112,-69.000839 -11.875278,-69.039459 -11.812778,-69.069458 -11.764168,-69.180557 -11.583612,-69.214737 -11.528057,-69.248901 -11.472502,-69.43251 -11.173613,-69.500565 -11.0625,-69.568436 -10.951092,-69.567505 -10.950556,-69.540558 -10.952223,-69.486954 -10.951113,-69.450836 -10.948057,-69.444458 -10.947224,-69.412231 -10.937778,-69.222778 -10.950834,-69.076126 -10.967224,-68.848892 -11.016111,-68.784454 -11.125,-68.779175 -11.133612,-68.774734 -11.136391,-68.764175 -11.139723,-68.757782 -11.140556,-68.700562 -11.134724,-68.654724 -11.124445,-68.620834 -11.11639,-68.58345 -11.106138,-68.569458 -11.1,-68.552231 -11.08889,-68.531113 -11.068335,-68.525284 -11.060001,-68.516953 -11.054445,-68.402512 -11.017778,-68.356674 -11.006111,-68.343903 -11.007502,-68.337784 -11.006945,-68.313065 -10.996668,-68.289169 -10.985556,-68.280563 -10.980001,-68.276947 -10.976667,-68.230286 -10.911667,-68.126678 -10.764168,-68.122513 -10.754446,-68.121124 -10.74889,-68.119736 -10.729445,-68.117508 -10.724724,-68.101959 -10.705278,-68.08223 -10.690279,-68.061111 -10.67639,-68.025848 -10.662779,-68.009445 -10.657778,-67.865845 -10.656946,-67.845566 -10.657501,-67.827789 -10.661112,-67.817505 -10.665279,-67.787231 -10.684168,-67.74556 -10.712502,-67.739182 -10.713335,-67.703339 -10.694723,-67.675003 -10.620001,-67.611679 -10.532223,-67.607788 -10.528057,-67.582504 -10.504446,-67.529175 -10.481112,-67.509171 -10.472778,-67.449448 -10.441668,-67.333344 -10.370001,-67.325012 -10.364445,-67.322784 -10.359724,-67.325562 -10.341667,-67.328339 -10.330557,-67.327515 -10.324446,-67.324173 -10.320835,-67.313065 -10.318056,-67.300293 -10.316668,-67.236389 -10.310556,-67.229172 -10.310556,-67.218063 -10.313334,-67.19751 -10.321112,-67.186401 -10.323612,-67.174454 -10.325001,-67.080841 -10.271946,-67.073059 -10.265556,-67.046402 -10.243612,-66.97084 -10.172224,-66.950012 -10.15139,-66.926682 -10.125278,-66.923889 -10.121113,-66.899445 -10.096668,-66.888062 -10.08639,-66.760284 -9.990835,-66.732224 -9.976946,-66.696396 -9.96389,-66.690567 -9.962502,-66.671112 -9.954168,-66.661392 -9.950001,-66.656403 -9.947779,-66.648056 -9.942223,-66.645004 -9.938057,-66.640015 -9.922224,-66.640259 -9.918272,-66.638062 -9.910557,-66.634445 -9.906946,-66.624725 -9.902779,-66.548889 -9.888334,-66.542511 -9.887501,-66.485565 -9.881111,-66.473068 -9.882502,-66.450012 -9.888056,-66.443619 -9.888889,-66.430283 -9.889446,-66.424454 -9.888056,-66.383347 -9.866667,-66.18306 -9.799723,-66.166946 -9.794724,-66.080841 -9.775278,-66.074448 -9.775835,-65.971954 -9.779724,-65.843903 -9.777779,-65.792236 -9.775002,-65.745834 -9.770557,-65.612793 -9.833057,-65.607788 -9.835001,-65.601669 -9.835835,-65.576126 -9.836945,-65.570007 -9.83639,-65.565567 -9.833612,-65.517502 -9.784168,-65.515289 -9.779446,-65.515015 -9.766111,-65.512222 -9.74139,-65.492508 -9.719168,-65.442337 -9.679195,-65.421951 -9.681946,-65.410568 -9.684723,-65.405014 -9.686111,-65.390015 -9.692223,-65.381958 -9.697779,-65.371948 -9.708889,-65.341949 -9.762501,-65.305847 -9.828056,-65.301117 -9.837223,-65.299454 -9.842779,-65.300842 -9.860556,-65.313904 -9.889168,-65.32251 -9.902224,-65.327225 -9.91139,-65.335007 -9.931391,-65.336945 -9.943056,-65.336945 -9.956945,-65.333618 -10.033056,-65.330841 -10.044168,-65.328613 -10.049168,-65.313065 -10.075279,-65.305283 -10.095278,-65.302231 -10.10639,-65.289459 -10.189167,-65.287781 -10.201668,-65.28862 -10.215,-65.289734 -10.220556,-65.309723 -10.283611,-65.313339 -10.29389,-65.319458 -10.301668,-65.330002 -10.311945,-65.341949 -10.321112,-65.353897 -10.330002,-65.375 -10.351112,-65.381393 -10.358612,-65.388901 -10.372501,-65.395775 -10.393579,-65.390839 -10.410557,-65.391678 -10.416945,-65.396957 -10.431946,-65.39917 -10.436945,-65.406677 -10.450001,-65.425842 -10.466112,-65.443024 -10.469349,-65.449509 -10.47924,-65.439178 -10.61278,-65.436951 -10.624723,-65.390015 -10.755835,-65.338623 -10.840834,-65.33168 -10.847502,-65.323242 -10.859617,-65.315842 -10.880835,-65.300568 -10.967224,-65.300568 -10.985279,-65.301956 -10.990557,-65.30751 -10.999168,-65.343338 -11.058056,-65.393616 -11.149445,-65.401947 -11.169724,-65.392792 -11.26639,-65.388626 -11.283056,-65.348343 -11.404724,-65.321396 -11.480721,-65.31279 -11.493057,-65.305557 -11.5,-65.301392 -11.502779,-65.296402 -11.504723,-65.283066 -11.50528,-65.258347 -11.501667,-65.240845 -11.505001,-65.235565 -11.507223,-65.2314 -11.51,-65.224457 -11.516668,-65.22139 -11.520834,-65.168625 -11.611946,-65.170288 -11.6175,-65.188339 -11.656389,-65.200836 -11.685556,-65.209167 -11.711668,-65.202515 -11.740002,-65.193344 -11.751945,-65.185562 -11.758057,-65.165009 -11.772501,-65.148621 -11.777224,-65.142227 -11.769445,-65.134171 -11.708612,-65.129456 -11.699446,-65.12149 -11.692755,-65.11528 -11.695278,-65.111679 -11.698891,-65.063339 -11.752501,-65.061401 -11.757223,-65.043335 -11.809723,-65.035568 -11.881668,-65.016953 -11.970001,-65.008347 -11.989445,-64.991669 -12.008057,-64.976959 -12.014168,-64.896118 -12.023335,-64.842514 -12.022779,-64.829178 -12.023613,-64.811951 -12.0275,-64.807236 -12.029724,-64.794449 -12.037779,-64.787781 -12.045279,-64.763336 -12.097778,-64.741959 -12.144724,-64.739731 -12.149445,-64.736389 -12.153057,-64.622513 -12.208889,-64.612793 -12.213057,-64.51973 -12.241945,-64.513336 -12.2425,-64.498337 -12.364168,-64.49556 -12.368334,-64.421402 -12.441113,-64.404709 -12.454514,-64.39418 -12.461668,-64.373062 -12.468334,-64.293304 -12.482069,-64.238892 -12.479168,-64.176392 -12.485556,-64.048889 -12.51,-64.0439 -12.511946,-64.036957 -12.51889,-64.028336 -12.531113,-64.024734 -12.534723,-64.015289 -12.539446,-63.940285 -12.549723,-63.933891 -12.55028,-63.918839 -12.54454,-63.898613 -12.528612,-63.87056 -12.493891,-63.832504 -12.474167,-63.797501 -12.460001,-63.671951 -12.470556,-63.476112 -12.564445,-63.466667 -12.576389,-63.464287 -12.587393,-63.464447 -12.604445,-63.415558 -12.653891,-63.394615 -12.668364,-63.33139 -12.703335,-63.318352 -12.705082,-63.252785 -12.707224,-63.241394 -12.704445,-63.230278 -12.694723,-63.216949 -12.68,-63.208618 -12.674446,-63.163338 -12.64889,-63.136642 -12.636353,-63.130051 -12.63541,-63.075005 -12.650002,-63.066971 -12.656124,-63.064171 -12.660278,-63.062263 -12.673071,-63.06321 -12.6919,-63.061394 -12.70389,-63.051674 -12.743057,-63.046669 -12.751945,-62.994171 -12.839333,-62.973763 -12.852898,-62.896667 -12.900278,-62.843842 -12.942339,-62.76973 -13.005835,-62.699173 -12.967501,-62.693199 -12.965878,-62.687225 -12.966667,-62.673424 -12.97435,-62.647064 -12.996946,-62.644173 -13.000834,-62.644173 -13.007502,-62.648056 -13.024168,-62.647064 -13.03084,-62.64389 -13.03389,-62.41922 -13.132523,-62.384727 -13.145834,-62.330833 -13.147779,-62.276947 -13.143612,-62.260109 -13.138172,-62.248894 -13.129446,-62.24028 -13.12389,-62.222778 -13.120001,-62.204727 -13.121946,-62.121948 -13.148335,-62.111946 -13.1525,-62.110405 -13.157001,-62.109726 -13.183334,-62.085556 -13.271389,-62.002502 -13.362223,-61.972946 -13.375429,-61.94445 -13.395834,-61.877861 -13.448866,-61.874451 -13.452223,-61.872208 -13.45734,-61.868446 -13.480877,-61.851395 -13.527224,-61.842079 -13.538309,-61.833893 -13.544724,-61.810066 -13.548666,-61.732864 -13.537369,-61.727501 -13.53639,-61.616394 -13.513056,-61.593529 -13.50724,-61.580833 -13.522223,-61.574173 -13.529724,-61.529724 -13.548334,-61.512558 -13.552431,-61.492783 -13.553335,-61.261642 -13.523087,-61.038979 -13.493118,-61.004173 -13.540834,-60.957779 -13.582779,-60.79937 -13.676552,-60.783836 -13.68236,-60.770653 -13.6833,-60.744293 -13.68236,-60.67556 -13.738611,-60.583336 -13.768612,-60.48278 -13.799723,-60.47084 -13.807222,-60.383896 -13.984446,-60.385109 -13.990072,-60.400558 -14.029724,-60.419174 -14.059723,-60.432503 -14.074446,-60.458618 -14.090834,-60.464729 -14.098612,-60.468056 -14.108891,-60.480835 -14.15139,-60.483025 -14.168957,-60.482079 -14.175547,-60.452423 -14.28586,-60.448616 -14.296391,-60.427475 -14.324305,-60.346504 -14.483418,-60.281113 -14.623335,-60.276115 -14.706667,-60.26445 -14.913612,-60.260002 -15.036667,-60.258896 -15.093613,-60.292503 -15.094446,-60.384727 -15.092501,-60.571396 -15.097502,-60.439728 -15.24139,-60.227226 -15.478613,-60.184448 -15.973612,-60.184174 -15.987223,-60.160278 -16.263058,-60.106674 -16.265835,-60.005562 -16.27,-59.532784 -16.289169,-59.489723 -16.290836,-58.972778 -16.310837,-58.541946 -16.326668,-58.44445 -16.330002,-58.433891 -16.329445,-58.419449 -16.322781,-58.410561 -16.317223,-58.403618 -16.309723,-58.397781 -16.301392,-58.391113 -16.287781,-58.386673 -16.278057,-58.327507 -16.279167,-58.325836 -16.306667,-58.324448 -16.396114,-58.34639 -16.506111,-58.358894 -16.522503,-58.36528 -16.529167,-58.397781 -16.553059,-58.419449 -16.573612,-58.431671 -16.59,-58.465836 -16.639168,-58.470001 -16.648891,-58.475769 -16.674633,-58.476395 -16.721668,-58.464172 -16.894169,-58.462784 -16.907223,-58.460556 -16.918892,-58.456947 -16.93,-58.448059 -16.948612,-58.442223 -16.956947,-58.437225 -16.965836,-58.43306 -16.976112,-58.424446 -17.009724,-58.408058 -17.105556,-58.40667 -17.118614,-58.40667 -17.138336,-58.409447 -17.190556,-58.403061 -17.226391,-58.397507 -17.249168,-58.391945 -17.258057,-58.386116 -17.265556,-58.371117 -17.278893,-58.351112 -17.287224,-58.328056 -17.292225,-58.315834 -17.293613,-58.294449 -17.299725,-58.25 -17.326115,-58.122223 -17.408058,-58.118896 -17.417503,-58.108894 -17.438892,-58.091667 -17.455559,-58.022781 -17.495556,-58.010559 -17.499725,-57.988174 -17.502876,-57.978947 -17.49851,-57.901672 -17.461945,-57.880836 -17.476948,-57.788063 -17.553612,-57.756218 -17.580269,-57.743057 -17.593056,-57.741394 -17.601112,-57.762505 -17.608612,-57.769173 -17.616947,-57.77948 -17.637741,-57.759171 -17.686947,-57.733063 -17.717224,-57.725838 -17.723892,-57.717285 -17.727577,-57.718174 -17.738583,-57.721115 -17.775002,-57.718895 -17.845001,-57.581673 -18.096111,-57.521118 -18.203892,-57.548889 -18.24028,-57.55584 -18.253334,-57.563339 -18.274723,-57.626945 -18.468056,-57.769447 -18.902779,-57.771118 -18.909447,-57.726341 -18.913322,-57.719727 -18.913891,-57.716667 -18.934448,-57.704727 -19.043613,-57.776672 -19.047501,-57.787224 -19.068058,-57.821396 -19.137222,-57.855003 -19.20639,-57.960556 -19.421112,-58.087227 -19.677223,-58.121117 -19.74139,-58.10334 -19.760281,-57.855694 -19.971636,-57.848747 -19.978794,-57.893059 -20.023891,-57.897507 -20.027225,-57.906395 -20.032501,-58.109726 -20.14917,-58.15889 -20.168056,-58.138062 -20.119167,-58.136391 -20.113613,-58.133057 -20.082226,-58.130562 -19.992226,-58.13195 -19.980003,-58.150558 -19.834167,-58.15139 -19.828056,-58.232224 -19.782501,-58.268059 -19.764168,-58.520561 -19.638615,-58.792618 -19.501507,-59.09584 -19.348892,-59.156395 -19.345558,-59.428337 -19.330002,-59.573616 -19.321667,-59.972778 -19.296947,-59.990837 -19.296669,-60.015938 -19.299427,-60.021118 -19.304726,-60.057503 -19.314724,-60.424446 -19.410835,-60.516396 -19.434723,-60.613335 -19.459167,-60.796394 -19.49028,-61.357224 -19.583057,-61.668892 -19.633335,-61.7425 -19.645,-61.774445 -19.724724,-61.847504 -19.910835,-61.913071 -20.080009,-62.101952 -20.337502,-62.198837 -20.47139,-62.269447 -20.562225,-62.267784 -20.621948,-62.265282 -20.742226,-62.264168 -20.810837,-62.261093 -21.000515,-62.258896 -21.056946,-62.377785 -21.426392,-62.470558 -21.714169,-62.474812 -21.728062,-62.486115 -21.765003,-62.524445 -21.883614,-62.601112 -22.120556,-62.634171 -22.221947,-62.643768 -22.238903,-62.655006 -22.237782,-62.659447 -22.234726,-62.765007 -22.154724,-62.789452 -22.12278,-62.79528 -22.108059,-62.795563 -22.101948,-62.790558 -22.085556,-62.792778 -22.058891,-62.799171 -22.022224,-62.800285 -22.01667,-62.804169 -22.006947,-62.808342 -21.999073,-62.811951 -21.996948,-62.818203 -21.996853,-62.830284 -21.99667,-62.886116 -21.99778,-63.13028 -22.000557,-63.593338 -22.003334,-63.685837 -22.003056,-63.733063 -22.002781,-63.941116 -22.000835,-63.993057 -22.094448,-64.058624 -22.249725,-64.126678 -22.410278,-64.169449 -22.466393,-64.175842 -22.474445,-64.194458 -22.491112,-64.202515 -22.49778,-64.206154 -22.5,-64.220291 -22.508614,-64.225845 -22.517223,-64.244171 -22.549725,-64.253342 -22.56778,-64.277786 -22.638615,-64.281403 -22.649445,-64.282501 -22.655556,-64.286118 -22.727501,-64.28389 -22.754448,-64.301392 -22.8325,-64.316391 -22.860558,-64.324722 -22.873611,-64.338623 -22.87167,-64.343903 -22.869446,-64.34584 -22.864445,-64.348068 -22.843056,-64.347778 -22.814167,-64.352509 -22.767223,-64.360001 -22.740837,-64.362503 -22.736668,-64.369736 -22.729446,-64.416397 -22.683613,-64.448898 -22.651947,-64.452515 -22.648335,-64.454453 -22.643333,-64.45668 -22.632225,-64.455841 -22.618614,-64.454727 -22.612503,-64.443893 -22.580002,-64.461945 -22.514446,-64.526123 -22.40889,-64.543625 -22.298889,-64.539459 -22.288612,-64.538345 -22.282501,-64.538895 -22.27639,-64.542511 -22.26667,-64.551392 -22.254448,-64.590561 -22.214725,-64.594727 -22.21167,-64.671677 -22.169724,-64.67984 -22.173964,-64.686111 -22.177223,-64.696671 -22.180836,-64.708618 -22.182781,-64.722778 -22.181393,-64.964447 -22.110001,-64.974457 -22.105278,-64.988342 -22.090836,-65.190201 -22.09473))";
            DrawBorder();
        }


        List<Polygon> getPolygons(string txt)
        {
            txt = Regex.Replace(txt, @"\(+", "(");
            txt = Regex.Replace(txt, @"\)+", ")");
            List<Polygon> polygons = new List<Polygon>();
            //if (txt.StartsWith("MULTIPOLYGON"))
            //{
            //    txt = txt.Substring(txt.IndexOf("(") + 1);
            //    txt = txt.Remove(txt.Length - 1);
            //}

            int ind = txt.IndexOf("(");
            while (ind != -1)
            {
                int end = txt.IndexOf(")", ind);
                //if (end != -1)
                //{
                    string tmp = txt.Substring(ind + 1, end - ind - 1);
                    Polygon pol = new Polygon();
                    string[] coordinates = tmp.Split(',');
                    List<Point> coordinateList = new List<Point>();
                    foreach (string s in coordinates)
                    {
                        string[] st = s.Split(' ');
                        float lon = float.Parse(st[0].Replace('.', ','));
                        float lat = float.Parse(st[1].Replace('.', ','));
                        //float lon = float.Parse(st[0]);
                        //float lat = float.Parse(st[1]);
                        pol.Points.Add(LatLongToPixelXY(lat, lon));
                    }
                    polygons.Add(pol);
                //}
                    ind = txt.IndexOf("(", end);
            }
            return polygons;
        }

        class Polygon
        {
            List<Point> _points;

            public List<Point> Points
            {
                get { return _points; }
                set { _points = value; }
            }

            public Polygon()
            {
                _points = new List<Point>();
            }
        }

        void DrawBorder()
        {
            _drawArea = Bitmap.FromFile("world.jpg");
            Graphics g = Graphics.FromImage(_drawArea);
            Pen pen = new Pen(Color.Red, 4);

            foreach (string line in _infos)
            {
                string[] tmp = line.Split(';');
                List<Polygon> polygons = getPolygons(tmp[0].Replace("\"", string.Empty));
                foreach (Polygon polygon in polygons)
                {
                    List<Point> coordinateList = polygon.Points;
                    for (int i = 0; i < coordinateList.Count - 1; i++)
                    {
                        Point p1 = coordinateList[i];
                        Point p2 = coordinateList[i + 1];
                        g.DrawLine(pen, p1, p2);
                    }
                    g.DrawLine(pen, coordinateList[coordinateList.Count - 1], coordinateList[0]);
                }
            }


            pictureBox1.Image = _drawArea;
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder,
        100L);
            myEncoderParameters.Param[0] = myEncoderParameter;

            _drawArea.Save("world_with_borders.jpg", jgpEncoder, myEncoderParameters);
            g.Dispose();
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private Point LatLongToPixelXY(float lat, float lon){
            Point p = new Point();
            p.X = (int)Math.Round((width / 360.0) * (180 + lon));
            p.Y = (int)Math.Round((height / 180.0) * (90 - lat));
	        return p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawBorder();
        }
    }
}
