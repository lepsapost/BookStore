# Scripts/recommendation.py
import sys

def get_recommendations(user_id):
    return [f"Book-{user_id}", "Python Basics", "C# Fundamentals"]

if __name__ == "__main__":
    user_id = int(sys.argv[1])  # Komut satırından kullanıcı ID'sini al
    recommendations = get_recommendations(user_id)
    print(recommendations)  # Önerileri çıktı olarak yazdır
