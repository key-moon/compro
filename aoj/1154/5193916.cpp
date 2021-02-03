// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1154/judge/5193916/C++17
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) {if(a > b) a = b;}
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) {if(a < b) a = b;}

using namespace std;

const int MAX = 300000;

int main(){
  set<int> prime{};
  vector<bool> notPrime(MAX + 1);
  for (int i = 2; i <= MAX; i++){
    if (i % 7 != 1 && i % 7 != 6) continue;
    if (notPrime[i]) continue;
    prime.insert(i);
    for (int j = i * 2; j <= MAX; j += i){
      notPrime[j] = true; 
    }
  }
  int n;
  while (cin >> n, n != 1){
    cout << n << ":";
    set<int> res{};
    for (int i = 1; i * i <= n; i++){
      if (n % i != 0) continue;
      res.insert(i);
      res.insert(n / i);
    }
    for (var&& elem : res){
      if (prime.count(elem)) cout << " " << elem;
    }
    cout << endl;
  }
}

