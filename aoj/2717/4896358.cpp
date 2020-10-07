// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2717/judge/4896358/C++14
#include<bits/stdc++.h>
using namespace std;
#define var auto

int main(){
  int n, m;
  cin >> n >> m;
  vector<int> fw(n, 0);
  int wSum, eSum = 0;
  for (int i = 0; i < m; i++){
    string s;
    cin >> s;
    for (int j = 0; j < n; j++){
      if (s[j] == 'W') fw[j]++;
    }
  }
  for (int i = 0; i < n; i++){
    wSum += fw[i];
  }
  int mi = wSum + eSum;
  //cout << mi << endl;
  int mind = -1;
  for (int i = 0; i < n; i++){
    int w = fw[i];
    int e = m - fw[i];
    wSum -= w;
    eSum += e;
    var cur = wSum + eSum;
    //cout << cur << endl;
    if (cur < mi){
      mi = cur;
      mind = i;
    }
  }
  cout << mind + 1 << " " << mind + 2 << endl;
}


