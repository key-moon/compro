// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1617/judge/4924288/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

bool solve(){
  string s1, s2;
  cin >> s1;
  if (s1 == ".") return false;
  cin >> s2;
  if (s1 == s2){
    cout << "IDENTICAL" << endl;
    return true;
  }
  bool isstr = false; 
  int wrong = 0;
  int i1, i2;
  for (i1 = 0, i2 = 0; i1 < s1.size() && i2 < s2.size(); i1++, i2++){
    if (s1[i1] == s2[i2]) {
      if (s1[i1] == '"') isstr = !isstr;
      continue;
    }
    if (!isstr) goto invalid;
    //次の引用符まで読み飛ばし
    while (i1 < s1.size() && s1[i1] != '"') i1++;
    while (i2 < s2.size() && s2[i2] != '"') i2++;
    //今引用符なはず
    if (i1 >= s1.size() || i2 >= s2.size()) goto invalid;
    i1++; i2++; isstr = !isstr;
    wrong++;
  }
  if (i1 < s1.size() || i2 < s2.size() || 1 < wrong) goto invalid;
  cout << "CLOSE" << endl;
  return true;
  invalid:;
  cout << "DIFFERENT" << endl;
  return true;
}

int main(){
  while (solve());
}

