// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1244/judge/4923759/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

map<string, int> h{};

// (...) を受け付ける
ll solve(string& s, int& i, bool& is_valid){
  assert(s[i] == '(');
  i++;
  ll res = 0;
  while (true){
    ll w;
    if (s[i] == ')') {
      i++;
      break;
    }
    if (s[i] == '(') w = solve(s, i, is_valid);
    else {
      string mol = "";
      mol += s[i];
      i++;
      if ('a' <= s[i] && s[i] <= 'z') {
        mol += s[i];
        i++;
      }
      if (h[mol] == 0) is_valid = false;
      w = h[mol];
    }
    if ('0' <= s[i] && s[i] <= '9'){
      int mul = 0;
      while ('0' <= s[i] && s[i] <= '9'){
        mul = mul * 10 + s[i] - '0';
        i++;
      }
      w *= mul;
    }
    res += w;
  }
  return res;
}

int main(){
  //mapで重さを持つ
  while (true){
    string mol;
    int n;
    cin >> mol;
    if (mol == "END_OF_FIRST_PART") break;
    cin >> n;
    h[mol] = n;
  }
  //括弧でstackに積む
  while (true){
    string s;
    cin >> s;
    if (s == "0") return 0;
    s = '(' + s + ')';
    int i = 0;
    bool is_valid = true;
    var res = solve(s, i, is_valid);
    if (is_valid) cout << res << endl;
    else cout << "UNKNOWN" << endl;
  }
}

