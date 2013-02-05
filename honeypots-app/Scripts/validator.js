/**
 *     Javascript Validation framework
 *     Author: ram.awasthi@timesgroup.com
 *     Version: 1.0
 *     Date: 1/24/2009
 *     Usage: 
  */    function validateForm(form) {
     var rules = new Rules();
	            
 		rules.addRule('fname','required',{args:'', errorMessage:'First name is required', 
 		                                  errorDiv:'eMsgFname', failedDiv:'errorFname', okDiv:'okFname'});
		rules.addRule('fname','minlength',{args:5, errorMessage:'First name should be 5 char long', 
		                                  errorDiv:'eMsgFname', failedDiv:'errorFname', okDiv:'okFname'}*		rules.addRule('fname','maxlength',{args:8, errorMessage:'First name should be max 8 char long', 
 		                                  errorDiv:'eMsgFname', failedDiv:'errorFname', okDiv:'okFname'});
		rules.addRule('fname','mask',{args:'^([a-zA-Z]*)$', errorMessage:'First name Albhabetic long', 
		                                  errorDiv:'eMsgFname', failedDiv:'errorFname', okDiv:'okFname'});
 
		rules.addRule('password','required',{args:'', errorMessage:'Password is required', 		                                  errorDiv:'eMsgPassword', failedDiv:'errorPassword', okDiv:'okPassword'});
		rules.addRule('password','minlength',{args:'', errorMessage:'Password should be 5 characters long', 
 		                                  errorDiv:'eMsgPassword', failedDiv:'errorPassword', okDiv:'okPassword'});
       var v = new Validator(form,rules);
 		 v.method = ALERT|TEXT|GLOBAL;
 		 v.globalDiv = 'allError';
 		//v.validate(true); //true means execute All Rules and false means exit whenever any rules breaks


 
 /*Error reporting Methods*/
 var ALERT  = 0x01; //Alert box
 var TEXT   = 0x02; //Text on div tag locally
 var GLOBAL = 0x04; //Global Div tag
 var DISPLAYTYPE = 'block';
 /* Class Validator */
 function Validator(form, rules) {
    this.form  = form;
	this.rules = rules;
	this.method = TEXT; // method can be ALERT or TEXT or GLOBAL
	this.i      = 0;
	this.focus  = "";
	this.status = true;
	this.globalDiv = "";
	this.errors ;
	
	if(this.displaytype == null || this.displaytype == undefined || this.displaytype == '')
		this.displaytype = DISPLAYTYPE;
	/* validates all rules */
	this.validate = function(executeAll) { //executeAll = true means execute all rules and false means execute until any rule breaks
	    this.errors = new Object();
		var valArray  = new Array();
		var curstatus = true; 
		for (var i in this.rules.fields) {
			var fields = this.rules.fields[i];
			var okDiv  = "";
			var errorDiv = ""; 
			var failedDiv = "";
            var pStatus = true;
			for(var j in fields) {
				var rule = fields[j];
				pStatus = this[j](i,rule);
				curstatus = curstatus & pStatus;
                okDiv     = rule['okDiv'];
				errorDiv  = rule['errorDiv'];
				failedDiv = rule['failedDiv'];
				/*exit on first error */
				if(pStatus == false) {
					if(this.focus  == ""){
						this.focus = i;
					}
					break;
				}

			}
		    if(pStatus == true && this.method & TEXT) {
				if(okDiv != '') {
				   document.getElementById(okDiv).style.display = 'none';
				}
				if(failedDiv != '') {
				   document.getElementById(failedDiv).style.display = 'none';
				}
				if(errorDiv != '') {
				   document.getElementById(errorDiv).style.display = 'none';
				}
			}
			if(executeAll == false && curstatus == false) {
                break;
			}
		}

		if(curstatus == false) {
			if(this.method & ALERT) {
				this.showAlert();
				this.form[this.focus].focus();
			}

			if(this.method & TEXT) {
				this.showText();
				if( this.form[this.focus]== "[object HTMLCollection]" ||this.form[this.focus] == '[object NodeList]' || (this.form[this.focus] == '[object]' && this.form[this.focus].length != undefined && this.form[this.focus].type == undefined)){
					try {
						this.form[this.focus][0].focus();
					}catch (e) {}
				}else{
					this.form[this.focus].focus();
				}
			}

			if(this.method & GLOBAL) {
				this.showGlobal();
			}
		}
		
		return curstatus;
	};

	/*this.validatePartial(id) {
		//var aIds = ids.split(",");
		//alert('len '+aIds.length);
		var curstatus = true;
		for (var i=0; i<id.length;i++) {
			var rule = id[i];
			curstatus = curstatus & this[rule](rule['element'],this.rules.fields[rule['element']]);
			//alert(this.status==false);
			if(curstatus == false) {			
				 break;
			}
		}
		return curstatus;
	}*/
	
	/*Trim a string (removes leading and trailing blanks)*/
	this.trim = function(s) {
		return s.replace( /^\s*/, "" ).replace( /\s*$/, "" );
	}
	
	/* Required rule makes a field mandatory*/
	this.required = function(element,data) {
		var field = this.form[element];
		
		//alert(field+"/"+field.name+"/"+field.length+"/"+field.type); 
		
		if(field == "[object HTMLCollection]" || field == "[object NodeList]" || (field == "[object]" && field.length != undefined && field.type == undefined)){
			var selectionFlag = false;
			for(var i = 0; i < field.length; i++){
				 if(field[i].checked)
					selectionFlag = true;
			}
			if(!selectionFlag){
				this.errors[field[0].name] = 'required';
				return false;
			}
		}else{
		
			if (field.type == "radio" && !field.checked) { 
				this.errors[field.name] = 'required';
				return false;
			}
			if (field.type == "checkbox" && !field.checked) { 
				this.errors[field.name] = 'required';
				return false;
			}
			
			if (field.type == 'text' ||
				field.type == 'textarea' ||
				field.type == 'file' ||
				field.type == 'select-one' ||
				field.type == 'select-multiple' ||
				field.type == 'radio' ||
				field.type == 'password') {
					var value = '';
					// get field's value
					
					if(field.type == "select-multiple") {
						var sl = 0;
						for(var c=0; c< field.options.length; c++) {
							//alert(field.options[c].value);
							if(field.options[c].selected == true && (field.options[c].value != "-1")) {
								sl++;
							}
						}
	
						if(sl > 0) {
							value = field.value;
						} else {
							value = "";
						}
	
					} else 	if (field.type == "select-one") {
								var si = field.selectedIndex;
								if (si >= 0) {
									value = field.options[si].value;
									if(value == -1) {
										value = "";
									}
								}
						} else {
							value = field.value;					
						}
			
					if ((this.trim(value)).length == 0) {
						this.errors[field.name] = 'required';
						return false;
					}
			}
		}
		return true; 
	}
	
	this.requiredif = function(element,data) {

		var ffield = this.form[element];
		var sfield = this.form[data["args"]];
		var bval   = false;
		var fvalue = false;
		var svalue = false;
		
		if (ffield.type == 'text' ||
			ffield.type == 'textarea' ||
			ffield.type == 'password') {
				if(Trim(ffield.value).length > 0)
					fvalue = true;
		}

		if (ffield.type == "select-one") {
			var si = ffield.selectedIndex;
			if (si >= 0) {
				if(ffield.options[si].value != -1)
					fvalue = true;
			}
		}
		
		if (ffield.type == "checkbox") {
				fvalue = ffield.checked;	
		}

		if(sfield.type == 'text' ||
		   sfield.type == 'textarea' ||
		   sfield.type == 'password') {
				if(Trim(sfield.value).length > 0)
					svalue = true;
		}

		if (sfield.type == "select-one") {
			var si = sfield.selectedIndex;
			if (si >= 0) {
				if(sfield.options[si].value != -1)
					svalue = true;
			}
		}

		if (sfield.type == "checkbox") {
				svalue = sfield.checked;
		}

		//alert(fvalue+"/"+svalue);
		
		if(fvalue && !svalue) {
			this.errors[ffield.name] = 'requiredif';
			return false;
		}
					
		return true;
	}
	
	this.matchfields = function(element, data) {
		var ffield = this.form[element];
		var sfield;
		var tVar = data["args"];
		var flag = true;
		if(tVar.indexOf("-") != -1 && tVar.split("-")[1] == "unequal"){
			flag = false;
			sfield = this.form[tVar.split("-")[0]];
		}else
	        sfield = this.form[tVar];
		
		if((ffield.type == 'text' || ffield.type == 'password') && (sfield.type == 'text' || sfield.type == 'password')) {
		   if(ffield.value != sfield.value && flag){
		   		this.errors[ffield.name] = 'matchfields';
				return false;
		   }else if(ffield.value == sfield.value && !flag){
		   		this.errors[ffield.name] = 'matchfields';
				return false;
		   }
		}
		return true;
	}

    //Minimum Length
	this.minlength = function(element,data) {

		var field = this.form[element];
		var length = data['args'];
		var value = "";

		if(field.type == 'text' ||
		   field.type == 'textarea' ||
		   field.type == 'password') {
			if(this.trim(field.value).length < length) {
				this.errors[field.name] = 'minlength';
				return false;
			}
		}

		if(field.type == 'select-multiple') {
			var sz = 0;
			
			for(var c=0; c < field.options.length; c++) {
				if(field.options[c].selected == true) {
					sz++;
				}
			}
			
            if(sz < length) {
            	this.errors[field.name] = 'minlength';
				return false;
			}

		}
		return true;
	}
	
	

	//Max length Length
	this.maxlength = function(element,data) {

		var field = this.form[element];
		var length = data['args'];
		var value = "";

		if(field.type == 'text' ||
		   field.type == 'textarea' ||
		   field.type == 'password') {
			if(field.value.length > length) {
				this.errors[field.name] = 'maxlength';
				return false;
			}
		}
		if(field.type == 'select-multiple') {
			var sz = 0;
			
			for(var c=0; c < field.options.length; c++) {
				if(field.options[c].selected == true) {
					sz++;
				}
			}
			
            if(sz > length) {
            	this.errors[field.name] = 'maxlength';
				return false;
			}

		}
		return true;
	}

	/*Validate Email Address */
	this.validemail = function(element, data) {
		var field = this.form[element];
				
		if(field.type == 'text') {
			var m = new RegExp('^[0-9a-zA-Z]+([0-9a-zA-Z-_]*[.]?)*([0-9a-zA-Z]+)@([0-9a-zA-Z-_]+[.])+([a-zA-Z]){2,4}$');
			 var a2 = (field.value).toLowerCase();
			if (!m.exec(this.trim(field.value))) {
				this.errors[field.name] = 'validemail';
				return false;
			}
			
			else if((a2).indexOf("@timesjobs.com")>1 || (a2).indexOf("@timesjob.com")>1 ){
				this.errors[field.name] = 'validemail';
				return false;
			}
		}
		
		return true;
	}
	
	/*Validate website url */
	this.validwebsiteurl = function(element, data) {
		var field = this.form[element];
				
		if(field.type == 'text') {
			var regUrl = /^(((ht|f){1}(tp:[/][/]){1})|((www.){1}))[-a-zA-Z0-9@:%_\+.~#?&//=]+$/;
			var a2 = this.trim((field.value).toLowerCase());
			
			if(a2.length > 0 && regUrl.test(a2) == false){
				this.errors[field.name] = 'validwebsiteurl';
				return false;
			}
		}
		return true;
	}

	/*Validate Mask rule matches value against given regular expression */
	this.mask = function(element,data) {
		var field = this.form[element];
		var args  = data['args'];
		if (field.type == 'text' ||
			field.type == 'textarea' ||
			field.type == 'password') {
			var m = new RegExp(args);
	
				if (!m.exec(field.value)) {
				    this.errors[field.name] = 'mask';
					//this.focus = field.name;
					return false;
				}
		}
		return true;
	}


    /****All Rules will be added above this line */
	this.showAlert = function () {
         var messages = new Array();
		 var i = 0;
		 for(var x in this.errors) {
			 if(i == 0) {
                this.focus = x;
			 }
			 i++;
			 //alert(this.rules.fields[x][this.errors[x]]['errorMessage']);
			 messages.push(this.rules.fields[x][this.errors[x]]['errorMessage']);
		 }
	}
	
	this.showGlobal = function () {
         var messages = new Array();
		 for(var x in this.errors) {
			 //alert(this.rules.fields[x][this.errors[x]]['errorMessage']);
			messages.push(this.rules.fields[x][this.errors[x]]['errorMessage']);
		 }
		 if(this.globalDiv != "") {
			 document.getElementById(this.globalDiv).innerHTML = messages.join("<br>");
		 }
	}

	this.showText = function () {
         var messages = new Array();

		 for(var x in this.errors) {
		 	
		 	 //alert(this.rules.fields[x][this.errors[x]]['errorMessage']+"/"+this.errors[x]);
			 var errorDiv = this.rules.fields[x][this.errors[x]]['errorDiv'];
			 var failedDiv  = this.rules.fields[x][this.errors[x]]['failedDiv'];
			 var okDiv  = this.rules.fields[x][this.errors[x]]['okDiv'];
			 var errorMsg = this.rules.fields[x][this.errors[x]]['errorMessage'];
			 document.getElementById(errorDiv).innerHTML = errorMsg;
			 document.getElementById(errorDiv).style.display = this.displaytype;
			 if(document.getElementById(failedDiv) != undefined && document.getElementById(failedDiv) != null)
			 	document.getElementById(failedDiv).style.display = '';
			 if(document.getElementById(okDiv) != undefined && document.getElementById(okDiv) != null)
			 	document.getElementById(okDiv).style.display = 'none';
			this.rules.fields[x][this.errors[x]]['errorMessage'];
		 }
		 //this.messages = messages.join("<br>");
	}
	
	this.checkNumeric = function(element) {
		var field = this.form[element];
		if (field.type == 'text'){
				if (isNaN(field.value)) {
				    this.errors[field.name] = 'checkNumeric';
					return false;
				}
		}
		return true;
	}
	
	this.validateWholeNumber = function(element){
	 	var ValidChars = "0123456789";
	    var IsNumber=true;
	    var Char;
		var field = this.form[element];
		if (field.type == 'text'){
			var componentValue = field.value;
			for (i = 0; i < componentValue.length && IsNumber == true; i++) 
			{ 
			  Char = componentValue.charAt(i);
			  if (ValidChars.indexOf(Char) == -1){
						 this.errors[field.name] = 'validateWholeNumber';
						IsNumber = false;
			   }
	   		}
		}
		return IsNumber;
	}	

this.validateBothFields=function(element,data){
		var field = this.form[element];
		var secondFieldName  = data['args'];
//	alert('field '+field+' sfield  '+secondFieldName);
		var fvalue = field.value;
		var svalue = this.form[secondFieldName].value;
		
	//	alert('fvalue '+fvalue+' svalue  '+svalue); 
		if(fvalue.length == 0 && svalue.length == 0){
			this.errors[field.name] = 'validateBothFields';
					return false;
		}
		return true; 
}
this.validateBothComboFields=function(element,data){
		var field = this.form[element];
		var secondFieldName  = data['args'];
//	alert('field '+field+' sfield  '+secondFieldName);
		var fvalue = field.value;
		var svalue = this.form[secondFieldName].value;
		
	//	alert('fvalue '+fvalue+' svalue  '+svalue); 
		if((fvalue.length == 0 && svalue.length == 0 )||(fvalue==-1 && svalue==-1)){
			this.errors[field.name] = 'validateBothComboFields';
					return false;
		}
		return true; 
}

//To check if from less than to
this.compareBothFields=function(element,data){
		var field = this.form[element];
		var secondFieldName  = data['args'];
		var fvalue = field.value;
		var svalue = this.form[secondFieldName].value;
		if(fvalue.length > 0 && svalue.length > 0){
		      if(parseInt(fvalue) > parseInt(svalue))
		      {
			      this.errors[field.name] = 'compareBothFields';
				  return false;
			  }
		}
		return true; 
}

this.compareBudgetFields=function(element,data){
		var field = this.form[element];
		if (field.type == "select-one")
		 {
			var secondFieldName  = data['args'];
			var i = field.selectedIndex;
			var j = this.form[secondFieldName].selectedIndex;
			if ((j<i) & (j != 0)){
			 	this.errors[field.name] = 'compareBudgetFields';
				var track = this.form[secondFieldName].selectedIndex;
				element.selectedIndex='0';
				return false;
			}
		}
		return true; 
}
//added by narendra for budget mandatory start
this.checkBudgetFields=function(element,data){
		var field = this.form[element];
		if (field.type == "select-one")
		 {
			var secondFieldName  = data['args'];
			var i = field.selectedIndex;
			var j = this.form[secondFieldName].selectedIndex;
			if ((j==0) ||(i==0)){
			 	this.errors[field.name] = 'checkBudgetFields';
				var track = this.form[secondFieldName].selectedIndex;
				element.selectedIndex='0';
				return false;
			}
		}
		return true; 
}//added by narendra for budget mandatory end

 } //Class Enclosing Brace


 /* Rules Class to Hold Rules Collection for each element*/
 function Rules() {
   this.fields = new Object();
 }

 Rules.prototype = {};

 Rules.prototype.addRule = function(element,rule,data) {
	//alert("Type:"+typeof this.fields[element]);
	if(typeof (this.fields[element]) == "undefined") {
		//alert('element');
		this.fields[element] = new Object();
	}
	this.fields[element][rule] = data;
	//alert(data['okDiv']);
   };