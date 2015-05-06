from app_service import app
import app_service.views.views

if __name__ == "__main__":
   app.debug = True
   app.run()
