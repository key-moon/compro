// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1195/judge/4924359/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

bool solve(){
  string s;
  cin >> s;
  if (s == "#") return false;
  int n = s.size();
  vector<string> res{};
  for (int i = 0; i < (1 << n); i++){
    bool valid = true;
    var t = s;
    for (int j = 0; j < n; j++){
      if (!(i >> j & 1)) continue;
      if (t[j] == 'z') {
        valid = false;
        break;
      }
      t[j]++;
    }
    if (!valid) continue;
    int flg = 1;
    for (int j = 0; j < n; j++){
      var id = t[j] - 'a';
      if ((flg >> id & 1) == 0){
        flg |= 1 << id;
        t[j]--;
      }
      if (s[j] != t[j]) goto end;
    }
    t = s;
    for (int j = 0; j < n; j++){
      if (!(i >> j & 1)) continue;
      t[j]++;
    }
    res.push_back(t);
    end:;
  }
  sort(res.begin(), res.end());
  cout << res.size() << endl;
  if (res.size() <= 10){
    for (int i = 0; i < res.size(); i++){
      cout << res[i] << endl;
    }
  }
  else{
    for (int i = 0; i < 5; i++){
      cout << res[i] << endl;
    }
    for (int i = res.size() - 5; i < res.size(); i++){
      cout << res[i] << endl;
    }
  }
  return true;
}

int main(){
  while (solve());
}

