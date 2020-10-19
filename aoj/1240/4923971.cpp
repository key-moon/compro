// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1240/judge/4923971/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

int main(){
  var C = [](string s){
    return s.substr(1) + s[0];
  };
  var J = [](string s){
    return s.back() + s.substr(0, s.size() - 1);
  };
  var E = [](string s){
    int n = s.size();
    var res = s.substr((n + 1) / 2); 
    if (s.size() % 2 == 1) res += s[n / 2];
    res += s.substr(0, n / 2);
    return res;
  };
  var M = [](string s){
    for (int i = 0; i < s.size(); i++){
      if (s[i] == '9') s[i] = '0';
      else if ('0' <= s[i] && s[i] < '9'){
        s[i]++;
      }
    }
    return s;
  };
  var P = [](string s){
    for (int i = 0; i < s.size(); i++){
      if (s[i] == '0') s[i] = '9';
      else if ('0' < s[i] && s[i] <= '9'){
        s[i]--;
      }
    }
    return s;
  };
  var A = [](string s){
    reverse(s.begin(), s.end());
    return s;
  };
  int n;
  cin >> n;
  for (int i = 0; i < n; i++){
    string q, s;
    cin >> q >> s;
    reverse(q.begin(), q.end());
    for (var&& c : q){
      switch (c){
      case 'A':
        s = A(s);
        break;
      case 'J':
        s = J(s);
        break;
      case 'C':
        s = C(s);
        break;
      case 'E':
        s = E(s);
        break;
      case 'P':
        s = P(s);
        break;
      case 'M':
        s = M(s);
        break;
      }
    }
    cout << s << endl;
  }
}

